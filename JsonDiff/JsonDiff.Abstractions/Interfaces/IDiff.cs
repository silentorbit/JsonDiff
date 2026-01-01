//Disable nullable here to suppor both nullable and non nullable classes
#nullable disable

namespace SilentOrbit.JsonDiff.Interfaces;

/// <summary>
/// Define the methods to be generated.
/// </summary>
public interface IDiff<T>
    where T : class
{
    /// <summary>
    /// Trim unchanged properties.
    /// Return true if entire class is unchanged.
    /// </summary>
    bool TrimIsUnchanged(T data);

    T ApplyTo(T data);
}
