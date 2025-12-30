namespace SilentOrbit.JsonDiff.Generator;

class SourceMethodGenerator : BaseGenerator
{
    public SourceMethodGenerator(DiffToGenerate spec) : base(spec)
    {
    }

    protected override void Generate()
    {
        //Helper
        w.Summary(DiffClassGenerator.CreateSummary);
        w.AppendLine($"public {DiffClassGenerator.Class} {DiffClassGenerator.Create}() => new(this);");
        w.AppendLine();

        w.Summary(DiffGeneratorClassGenerator.CreateSummary);
        w.AppendLine($"public {DiffGeneratorClassGenerator.Class} {DiffGeneratorClassGenerator.Create}() => new(this);");
        w.AppendLine();
    }

}
