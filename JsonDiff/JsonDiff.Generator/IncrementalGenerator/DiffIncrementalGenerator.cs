using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace SilentOrbit.JsonDiff.IncrementalGenerator;

[Generator]
class DiffIncrementalGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        // Do a simple filter for enums
        var filter = context.SyntaxProvider
            .ForAttributeWithMetadataName(typeof(JsonDiffClassAttribute).FullName, Predicate, Transform)
            .Where(static m => m is not null);

        // Generate source code for each enum found
        context.RegisterSourceOutput(filter, Execute);
    }

    static bool Predicate(SyntaxNode syntaxNode, CancellationToken cancellationToken)
    {
        return true;
    }

    static DiffToGenerate? Transform(GeneratorAttributeSyntaxContext context, CancellationToken cancellationToken)
    {
        if (context.SemanticModel.GetDeclaredSymbol(context.TargetNode) is not INamedTypeSymbol symbol)
        {
            Debug.Fail("something went wrong");
            return null;
        }

        var sourceClassName = new FullName(null, symbol);

        var toGenerate = new DiffToGenerate(sourceClassName);
        ExtractAttributeArguments(context, toGenerate);

        var symbolMembers = symbol.GetMembers();
        foreach (ISymbol member in symbolMembers)
        {
            try
            {
                if (member.IsStatic)
                    continue;
                if (member is not IPropertySymbol namedMember)
                    continue;
                if (MemberToGenerate.IsIgnore(namedMember))
                    continue;
                
                var memberAttributes = new MemberToGenerate(namedMember);

                toGenerate.Members.Add(memberAttributes);
            }
            catch (Exception ex)
            {
                Debug.Fail(ex.Message);
                throw;
            }
        }

        // Create an EnumToGenerate for use in the generation phase
        return toGenerate;
    }

    static void ExtractAttributeArguments(GeneratorAttributeSyntaxContext context, DiffToGenerate toGenerate)
    {
        var targetNode = context.TargetNode as ClassDeclarationSyntax;
        if (targetNode == null)
        {
            Debug.Fail("something went wrong");
            return;
        }

        foreach (var a in targetNode.AttributeLists)
        {
            foreach (var a2 in a.Attributes)
            {
                var name = context.SemanticModel.GetTypeInfo(a2).Type!.ToDisplayString();
                if (name != typeof(JsonDiffClassAttribute).FullName)
                    continue;
                if (a2.ArgumentList == null)
                    continue;
                foreach (var arg in a2.ArgumentList.Arguments)
                {
                    var nameEquals = arg.NameEquals?.Name.Identifier.ValueText;
                    switch (nameEquals)
                    {
                        case nameof(JsonDiffClassAttribute.AssertLevel):
                            switch (arg.Expression)
                            {
                                case MemberAccessExpressionSyntax e:
                                    if (Enum.TryParse<AssertLevel>(e.GetLastToken().ValueText, out var level))
                                        toGenerate.Attribute.AssertLevel = level;
                                    else
                                        throw new NotImplementedException();
                                    break;

                                default: 
                                    throw new NotImplementedException(arg.Expression.GetType().FullName);
                            }
                            break;

                        case nameof(JsonDiffClassAttribute.HandleUnexpectedNull):
                            switch (arg.Expression)
                            {
                                case LiteralExpressionSyntax l:
                                    toGenerate.Attribute.HandleUnexpectedNull = (bool)l.Token.Value!;
                                    break;

                                default: 
                                    throw new NotImplementedException(arg.Expression.GetType().FullName);
                            }
                            break;

                        case null: break;
                        default: throw new NotImplementedException();
                    }

                    var nameColon = arg.NameColon?.Name.Identifier.ToFullString();
                    switch (nameColon)
                    {
                        case null:
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                }
            }
        }
    }

    /// <summary>
    /// <see cref="IIncrementalGenerator.RegisterSourceOutput"/>>
    /// </summary>
    static void Execute(SourceProductionContext context, DiffToGenerate? spec)
    {
        Debug.Assert(spec != null);
        if (spec == null)
            return;

        var dic = new Dictionary<string, BaseGenerator> {
            { "Base", new SourceMethodGenerator(spec) },
            { DiffClassGenerator.Class, new DiffClassGenerator(spec) },
            { DiffGeneratorClassGenerator.Class, new DiffGeneratorClassGenerator(spec) },
        };

        // Create a separate partial class file for each enum
        foreach (var kvp in dic)
        {
            var src = kvp.Value.GenerateSource();
            context.AddSource($"{spec.SourceType}.{kvp.Key}.g.cs", SourceText.From(src, Encoding.UTF8));
        }
    }

}