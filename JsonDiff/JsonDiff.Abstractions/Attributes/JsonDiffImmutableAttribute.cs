namespace SilentOrbit.JsonDiff.Attributes;

/// <summary>
/// The class is immutable, change is only possible by creating a new instance.
/// This will be treated as a primitive.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
public class JsonDiffImmutableAttribute : Attribute
{
}
