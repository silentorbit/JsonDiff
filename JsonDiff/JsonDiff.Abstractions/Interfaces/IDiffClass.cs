//Disable nullable here to suppor both nullable and non nullable classes
#nullable disable

namespace SilentOrbit.JsonDiff.Interfaces;

/// <summary>
/// Define the methods to be generated.
/// </summary>
public interface IDiffClass<T, TDiff, TDiffGenerator>
    where T : class
    where TDiff : class, IDiff<T>, new()
    where TDiffGenerator : DiffGeneratorBase<T, TDiff>
{
    /// <summary>
    /// Create a full <see cref="IDiff{T}"/> as reference for later use with <see cref="IDiff{T}.TrimIsUnchanged(T)"/>.
    /// </summary>
    TDiff CreateReferenceDiff();

    /// <summary>
    /// Create a generator that starts with an empty <see cref="IDiff{T}"/> and update it as changes are made to this instance.
    /// </summary>
    TDiffGenerator CreateDiffGenerator();
}
