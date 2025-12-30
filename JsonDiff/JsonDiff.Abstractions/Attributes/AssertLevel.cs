namespace SilentOrbit.JsonDiff.Attributes;

public enum AssertLevel
{
    /// <summary>
    /// No generation
    /// </summary>
    None,

    /// <summary>
    /// Generate <see cref="Debug.Assert(bool)"/>
    /// </summary>
    Debug,

    /// <summary>
    /// Throw Exception on invalid test.
    /// </summary>
    Exception,

}
