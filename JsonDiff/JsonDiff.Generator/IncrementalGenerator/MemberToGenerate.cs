using Microsoft.CodeAnalysis;
using SilentOrbit.JsonDiff.Generator;
using System.Text.Json.Serialization;

namespace SilentOrbit.JsonDiff.IncrementalGenerator;

record MemberToGenerate
{
    public IPropertySymbol Symbol;

    public string Name;
    public string? RevisionName
    {
        get
        {
            switch (PropertyType)
            {
                case PropertyType.Value:
                case PropertyType.ValueNullable:
                case PropertyType.Class:
                case PropertyType.ClassNullable:
                    return null;
                case PropertyType.Revision:
                case PropertyType.RevisionNullable:
                    return $"{Name}_Diff";
                default:
                    throw new NotImplementedException(PropertyType.ToString());
            }
        }
    }

    public FullName Type;
    /// <summary>
    /// <see cref="Type"/> without nullable "?"
    /// </summary>
    public FullName Class;

    public PropertyType PropertyType;

    public string? JsonPropertyName;

    /// <summary>
    /// Has <see cref="JsonDiffFullAttribute"/>
    /// Member should be diff generated to full instance if modified.
    /// 
    /// Only needed to override 
    /// <see cref="JsonDiffClassAttribute"/> or <see cref=""/>
    /// for individual properties
    /// </summary>
    public bool IsFullClone { get; }

    /// <summary>
    /// Has <see cref="JsonDiffAlwaysAttribute"/>
    /// </summary>
    public bool IsDiffAlways { get; }

    /// <summary>
    /// <see cref="JsonDiffIgnoreAttribute"/> or
    /// <see cref="JsonIgnoreAttribute"/>
    /// </summary>
    public static bool IsIgnore(IPropertySymbol symbol)
    {
        foreach (var a in symbol.GetAttributes())
        {
            var displayName = a.AttributeClass!.Name;
            switch (displayName)
            {
                case nameof(JsonDiffIgnoreAttribute):
                case nameof(JsonIgnoreAttribute):
                    return true;
            }
        }
        return false;
    }

    public MemberToGenerate(IPropertySymbol symbol)
    {
        Symbol = symbol;
        Name = symbol.Name;
        Type = new FullName(null, symbol.Type);
        Class = Type.Nullable(false);

        foreach (var a in symbol.GetAttributes())
        {
            var displayName = a.AttributeClass!.Name;
            switch (displayName)
            {
                case nameof(JsonDiffIgnoreAttribute):
                case nameof(JsonIgnoreAttribute):
                    Debug.Fail("Should already have been ignored before this");
                    return;

                case nameof(JsonDiffAlwaysAttribute):
                    IsDiffAlways = true;
                    break;

                case nameof(JsonDiffFullAttribute):
                    Debug.Assert(symbol.Type.IsReferenceType,
                        $@"[{nameof(JsonDiffFullAttribute)}] is not supported on property ""{Name}"" with value type {Type.Name}, only classes.");

                    IsFullClone = true;
                    break;

                case nameof(JsonPropertyNameAttribute):
                    Debug.Assert(a.ConstructorArguments.Length == 1);
                    JsonPropertyName = (string?)a.ConstructorArguments[0].Value;
                    break;
            }
        }

        //PropertyType
        if (IsFullClone)
        {
            if (Type.IsNullable)
                PropertyType = PropertyType.ClassNullable;
            else
                PropertyType = PropertyType.Class;
        }
        else if (Type.IsImmutable || Type.IsValueType)
        {
            if (Type.IsNullable)
                PropertyType = PropertyType.ValueNullable;
            else
                PropertyType = PropertyType.Value;
        }
        else if (Type.IsRevClass)
        {
            if (Type.IsNullable)
                PropertyType = PropertyType.RevisionNullable;
            else
                PropertyType = PropertyType.Revision;
        }
        else
        {
            if (Type.IsNullable)
                PropertyType = PropertyType.ClassNullable;
            else
                PropertyType = PropertyType.Class;
        }

    }

    /// <summary>
    /// Type for change properties in Rev
    /// Also backwards compatible for change properties where otherwise revision properties are used
    /// </summary>
    public string ChangeType
    {
        get
        {
            if (IsDiffAlways)
            {
                switch (PropertyType)
                {
                    case PropertyType.Value:
                    case PropertyType.Class:
                    case PropertyType.Revision:
                        return $"{Class}";
                    case PropertyType.ValueNullable:
                    case PropertyType.ClassNullable:
                    case PropertyType.RevisionNullable:
                        return $"{Class}?";
                    default:
                        throw new NotImplementedException(PropertyType.ToString());
                }
            }

            switch (PropertyType)
            {
                case PropertyType.Value:
                case PropertyType.Class:
                case PropertyType.Revision:
                    return $"{Class}?";
                case PropertyType.ValueNullable:
                case PropertyType.ClassNullable:
                case PropertyType.RevisionNullable:
                    return $"{nameof(JsonNullableChanged<>)}<{Class}?>?";
                default:
                    throw new NotImplementedException(PropertyType.ToString());
            }
        }
    }

    /// <summary>
    /// For use in <see cref="JsonConverterAttribute"/>
    /// </summary>
    public string? RevChangeJsonConverterType
    {
        get
        {
            switch (PropertyType)
            {
                case PropertyType.Value:
                case PropertyType.Class:
                case PropertyType.Revision:
                    return null;
                case PropertyType.ValueNullable:
                case PropertyType.ClassNullable:
                case PropertyType.RevisionNullable:
                    return $"{nameof(JsonNullableChangedConverter<>)}<{Type}>";
                default:
                    throw new NotImplementedException($"{nameof(RevChangeJsonConverterType)} from {PropertyType}");
            }
            ;
        }
    }

    /// <summary>
    /// Type for properties in Rev
    /// </summary>
    public string? RevisionType
    {
        get
        {
            switch (PropertyType)
            {
                case PropertyType.Value:
                case PropertyType.ValueNullable:
                case PropertyType.Class:
                case PropertyType.ClassNullable:
                    return null;
                case PropertyType.Revision:
                case PropertyType.RevisionNullable:
                    return $"{Class}.{DiffClassGenerator.Class}?";
                default:
                    throw new NotImplementedException(PropertyType.ToString());
            }
        }
    }

    public override string ToString()
    {
        return $"{Type} {Name} {(IsFullClone ? "Full" : "")}";
    }
}