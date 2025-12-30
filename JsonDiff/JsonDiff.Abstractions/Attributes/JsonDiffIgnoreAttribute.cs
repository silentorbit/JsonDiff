namespace SilentOrbit.JsonDiff.Attributes;

/// <summary>
/// This value never changes
/// Do not include in diff algorithm.
/// Will still be serialized on the main class but not in revisions.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class JsonDiffIgnoreAttribute : Attribute
{
}
