namespace SilentOrbit.JsonDiff.IncrementalGenerator;

class DiffToGenerate
{
    public readonly FullName SourceType;
    public List<MemberToGenerate> Members { get; } = new();

    public JsonDiffClassAttribute Attribute { get; } = new();

    public DiffToGenerate(FullName sourceType)
    {
        SourceType = sourceType;
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }


}
