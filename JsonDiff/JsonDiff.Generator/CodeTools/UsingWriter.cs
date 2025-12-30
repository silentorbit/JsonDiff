namespace SilentOrbit.JsonDiff.CodeTools;

/// <summary>
/// For generating 
/// {
///     Indented code wrapped in {}
/// }
/// </summary>
class UsingWriter : IDisposable
{
    readonly SourceWriter w;
    readonly string? lastLine;
    readonly bool indent;

    public UsingWriter(SourceWriter w, string? lastLine = null, bool indent = true)
    {
        this.w = w;
        this.lastLine = lastLine;
        this.indent = indent;

        if (indent)
            w.Indent();
    }

    public virtual void Dispose()
    {
        if (indent)
            w.Outdent(lastLine);
        else
            w.AppendLine(lastLine);
    }

}
