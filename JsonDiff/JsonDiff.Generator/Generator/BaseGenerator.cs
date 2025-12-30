namespace SilentOrbit.JsonDiff.Generator;

abstract class BaseGenerator
{
    protected readonly DiffToGenerate spec;
    protected readonly SourceWriter w;
    protected readonly FullName sourceClass;
    protected readonly MemberToGenerate[] members;

    //Code generated
    protected const string JsonClone = $"{nameof(Tools.JsonClone)}.{nameof(Tools.JsonClone.Clone)}";
    protected const string JsonCompare = $"{nameof(Tools.JsonClone)}.{nameof(Tools.JsonClone.Compare)}";
    /// <summary>
    /// <see cref="JsonNullableChanged{T}.Changed"/>
    /// </summary>
    protected const string NullChanged = nameof(JsonNullableChanged<>.Changed);

    protected BaseGenerator(DiffToGenerate spec)
    {
        this.spec = spec;

        w = new SourceWriter(spec);

        w.Using<System.Collections.Generic.List<object>>();
        w.Using("Debug = System.Diagnostics.Debug");
        w.Using<SilentOrbit.JsonDiff.Interfaces.JsonNullableChanged<string>>();
        w.Using<SilentOrbit.JsonDiff.Tools.JsonNullableChangedConverter<string>>();
        w.Using<System.Text.Json.Serialization.JsonAttribute>();

        sourceClass = w.Scope.Trim(spec.SourceType);

        members = spec.Members
            .Select(m => m with { Type = w.Scope.Trim(m.Type) })
            .ToArray();
    }

    public string GenerateSource()
    {
        //Implementation inside existing class
        using (w.Class($"{spec.SourceType.Accessibility} partial", spec.SourceType, 
            extends: $"{nameof(IDiffClass<,,>)}<{spec.SourceType.Name},{spec.SourceType.Name}.{DiffClassGenerator.Class},{spec.SourceType.Name}.{DiffGeneratorClassGenerator.Class}>"))
        {
            Generate();
        }

        return w.ToString();
    }

    protected abstract void Generate();
}
