namespace SilentOrbit.JsonDiff.Attributes;

/// <summary>
/// This value is expected to ALWAYS change.
/// A diff will always have the original value.
/// Not a criteria for change detection.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class JsonDiffAlwaysAttribute : Attribute
{
}
