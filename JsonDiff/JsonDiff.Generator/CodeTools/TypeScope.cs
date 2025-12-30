namespace SilentOrbit.JsonDiff.CodeTools;

class TypeScope
{
    readonly List<string> usings = new();

    internal void Add(string? usingNamespace)
    {
        if (usingNamespace == null)
            return;
        usings.Add(usingNamespace);
    }

    /// <summary>
    /// Return short type if found in usings or full type otherwise.
    /// </summary>
    internal FullName Trim(FullName type)
    {
        if (type.Namespace == null)
            return type;

        foreach (var u in usings)
        {
            if (u == type.Namespace)
                return type with { Namespace = null };

            if (type.Namespace.StartsWith(u + "."))
                return type with { Namespace = type.Namespace.Substring(u.Length + 1) };
        }

        return type;
    }
}
