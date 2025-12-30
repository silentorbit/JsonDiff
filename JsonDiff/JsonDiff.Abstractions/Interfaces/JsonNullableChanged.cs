namespace SilentOrbit.JsonDiff.Interfaces;

/// <summary>
/// Helper to serialize a nullable value.
/// We must be able to differentiate between
/// changing to null vs not modified.
/// </summary>
public class JsonNullableChanged<T>
{
    /// <summary>
    /// If null, will serialize to JSON null.
    /// </summary>
    public T Changed { get; set; } = default!;

    public override string ToString() => Changed?.ToString() ?? "null";
}
