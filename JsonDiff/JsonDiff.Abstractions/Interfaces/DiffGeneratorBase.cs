namespace SilentOrbit.JsonDiff.Interfaces;

/// <summary>
/// Base class from <see cref="IDiffClass{TDiff, TDiffGenerator}.CreateDiffGenerator"/>
/// </summary>
/// <typeparam name="T"></typeparam>
/// <typeparam name="TDiff"></typeparam>
/// <param name="data"></param>
public abstract class DiffGeneratorBase<T, TDiff>(T data)
    where T : class
    where TDiff : class, IDiff<T>, new()
{
    public TDiff Rev { get; } = new();
    public T Data = data;
}
