using Microsoft.CodeAnalysis;

namespace SilentOrbit.JsonDiff.CodeTools;

record FullName
{
    public ITypeSymbol? Symbol;

    public string? Namespace;
    public string? ParentClass;
    public string Name;

    /// <summary>
    /// Is a class
    /// </summary>
    public bool IsReferenceType;
    /// <summary>
    /// Is a struct or primitive type
    /// </summary>
    public bool IsValueType => !IsReferenceType;

    public bool IsNullable;

    /// <summary>
    /// True if <see cref="Type"/> has <see cref="JsonDiffClassAttribute"/>
    /// </summary>
    public bool IsRevClass;

    /// <summary>
    /// True if <see cref="Type"/> has <see cref="JsonDiffImmutableAttribute"/>
    /// </summary>
    public bool IsImmutable;

    public string Accessibility => Symbol?.DeclaredAccessibility switch
    {
        null => "/* SymbolNull */",
        Microsoft.CodeAnalysis.Accessibility.Public => "public",
        Microsoft.CodeAnalysis.Accessibility.Internal => "internal",
        _ => $"<{Symbol.DeclaredAccessibility}>"
    };

    public static FullName From<T>()
    {
        var t = typeof(T);
        Debug.Assert(t.FullName.StartsWith(t.Namespace));
        return new FullName(t.FullName.Substring(t.Namespace.Length + 1).Replace("+", "."));
    }

    public FullName(string? name, ITypeSymbol? type = null)
    {
        Symbol = type;

        if (name == null)
        {
            Debug.Assert(type != null);
            Namespace = type!.ContainingNamespace.ToDisplayString();
            Name = type.ToDisplayString();
            if (Name.StartsWith(Namespace + "."))
                Name = Name.Substring(Namespace.Length + 1);

            var sep = Name.LastIndexOf('.');
            if(sep != -1)
            {
                ParentClass = Name.Substring(0, sep);
                Name = Name.Substring(sep + 1);
                throw new NotImplementedException($"Nested classes: {type.ToDisplayString()} {type?.Name}");
            }

            IsReferenceType = GetIsReference(type);

            IsRevClass = HasAttribute(type, nameof(JsonDiffClassAttribute));
            IsImmutable = HasAttribute(type, nameof(JsonDiffImmutableAttribute));
        }
        else
        {
            Namespace = null;
            Name = name;
        }

        IsNullable = Name.EndsWith("?");
    }

    /// <summary>
    /// Property type has the <see cref="T"/> Attribute
    /// </summary>
    static bool HasAttribute(ITypeSymbol type, string nameofAttribute)
    {
        if (type.IsValueType)
            return false;

        foreach (var a in type.GetAttributes())
            if (a.AttributeClass!.Name == nameofAttribute)
                return true;
        return false;
    }

    static bool GetIsReference(ITypeSymbol type)
    {
        switch (type.SpecialType)
        {
            case SpecialType.System_Boolean:
            case SpecialType.System_SByte:
            case SpecialType.System_Int16:
            case SpecialType.System_Int32:
            case SpecialType.System_Int64:
            case SpecialType.System_Byte:
            case SpecialType.System_UInt16:
            case SpecialType.System_UInt32:
            case SpecialType.System_UInt64:
            case SpecialType.System_Single:
            case SpecialType.System_Double:
            case SpecialType.System_Char:
            case SpecialType.System_String:
            case SpecialType.System_Object:
                return false;
        }
        switch (type.TypeKind)
        {
            case TypeKind.Array:
            case TypeKind.Class:
                return true;
            case TypeKind.Enum:
            case TypeKind.Struct:
                return false;
            case TypeKind.Error:
                Debug.Fail($"Error type kind {type.TypeKind}");
                return false;
        }

        Debug.Fail($"Unknown type kind {type.TypeKind}");
        return false;
    }

    public override string ToString()
    {
        if (Namespace == null || Namespace == "System")
            return Name;
        return $"{Namespace}.{Name}";
    }

    public FullName Nullable(bool nullable)
    {
        var trimName = Name.TrimEnd('?');
        if (nullable)
            return this with { Name = trimName + '?' };
        else
            return this with { Name = trimName };
    }
}
