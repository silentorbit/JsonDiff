namespace SilentOrbit.JsonDiff.Attributes;

/// <summary>
/// Generate a subclass "Rev" to track changes to this class.
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class JsonDiffClassAttribute : Attribute
{
    /// <summary>
    /// Handle unexpected null values.
    /// True: Treat all possible null properties as if their type is nullable.
    /// False: Crash on unexpected null value.
    /// </summary>
    public bool HandleUnexpectedNull { get; set; }

    public AssertLevel AssertLevel { get; set; }
}
