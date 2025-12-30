using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using SilentOrbit.JsonDiff.Attributes;
using SilentOrbit.JsonDiff.IncrementalGenerator;

namespace SilentOrbit.JsonDiff.Test;

#if DEBUG || SOURCEGENERATION

/// <summary>
/// This test is used for debugging the source generator.
/// </summary>
[TestClass]
public class SourceGeneratorDebugging
{
    [TestMethod]
    public void TestGenerator()
    {
        var source = $$"""
using System.Collections.Generic;
using SilentOrbit.JsonDiff.Attributes;

namespace TestNamespace.SubNamespace;

[JsonDiffClass(AssertLevel = AssertLevel.None, HandleUnexpectedNull = true)]
public partial class TestA
{
    public string S1 { get; set; }
    public string? S2Nullable { get; set; }

    [JsonDiffFullClone]
    public Dictionary<string, TestD>? Exports { get; set; }

    public DateTime? Value1 { get; set; }
    
    [JsonDiffAlways]
    public DateTime Modified { get; set; }
    
    [JsonDiffIgnore]
    public int Value2 { get; set; }
    
    public TestA ValueA1 { get; set; }
    
    public TestB ValueB1 { get; set; }
    
    [JsonDiffFullClone]
    public TestB ValueB2 { get; set; }

    public TestC ValueC1 { get; set; }

    public TestD ValueD1 { get; set; }
}

[JsonDiffClass]
public partial class TestB
{
    public int ValueB3 { get; set; }
    public int ValueB4 { get; set; }
}

[JsonDiffImmutable]
public class TestC
{
    public int ValueB3 { get; set; }
    public int ValueB4 { get; set; }
}

public class TestD
{
    public int ValueB3 { get; set; }
    public int ValueB4 { get; set; }
}
""";

        var generator = new DiffIncrementalGenerator();

        var compilation = CSharpCompilation.Create("CSharpCodeGen.GenerateAssembly")
            .AddSyntaxTrees(CSharpSyntaxTree.ParseText(source))
            .AddReferences(MetadataReference.CreateFromFile(typeof(object).Assembly.Location))
            .AddReferences(MetadataReference.CreateFromFile(typeof(JsonDiffClassAttribute).Assembly.Location))
            .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        var driver = CSharpGeneratorDriver.Create(generator)
            .RunGeneratorsAndUpdateCompilation(compilation, out _, out var _);

        // Verify the generated code
        var result = driver.GetRunResult();

        //Only for debugging the generator, not to verify the generated results.
        Assert.HasCount(1, result.Results);
        //Assert.HasCount(3, result.Results[0].GeneratedSources);
        foreach (var s in result.Results[0].GeneratedSources)
        {
            var src = s.SourceText.ToString();
            Console.WriteLine(src);
        }
    }
}

#endif