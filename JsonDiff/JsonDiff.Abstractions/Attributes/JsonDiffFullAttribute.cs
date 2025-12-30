namespace SilentOrbit.JsonDiff.Attributes;

/// <summary>
/// Override <see cref="JsonDiffClassAttribute"/> on a specific property.
/// Treat changes in this like a new value.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class JsonDiffFullAttribute : Attribute
{
}
