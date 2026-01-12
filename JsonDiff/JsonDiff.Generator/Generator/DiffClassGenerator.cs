namespace SilentOrbit.JsonDiff.Generator;

class DiffClassGenerator(DiffToGenerate spec) : BaseGenerator(spec)
{
    //Rev
    internal const string Class = "Diff";
    internal const string CreateSummary = $"Create a full copy as a delta.\nUse with {nameof(IDiff<>.TrimIsUnchanged)}";
    internal const string Create = nameof(IDiffClass<,,>.CreateReferenceDiff);

    protected override void Generate()
    {
        //class Rev
        using (w.Class("public partial",
            classname: new(Class),
            extends: $"{nameof(IDiff<>)}<{sourceClass}>",
            generatedCodeAttribute: true
            ))
        {
            ChangeProperties();
            w.AppendLine();
            DiffProperties();
            w.AppendLine();
            Constructors();
            w.AppendLine();
            TrimIsUnchanged();
            w.AppendLine();
            ApplyTo();
        }
    }

    #region Properties

    void ChangeProperties()
    {
        using var _ = w.Region("Change Properties");
        foreach (var member in members)
        {
            w.Summary($@"<see cref=""{sourceClass}.{member.Name}""/>");
            w.JsonConverter(member.RevChangeJsonConverterType);
            if (member.JsonPropertyName != null && member.JsonPropertyName != member.Name)
                w.JsonPropertyName(member.JsonPropertyName);
            w.Property("public", member.ChangeType, member.Name);
            w.AppendLine();
        }
    }

    void DiffProperties()
    {
        const string jsonPrefix = "^";
        using var _ = w.Region("Diff Properties \"^...\"");
        foreach (var member in members)
        {
            if (member.RevisionType == null)
                continue;

            w.Summary($@"<see cref=""{sourceClass}.{member.Name}""/>");
            var name = member.JsonPropertyName ?? member.Name;
            w.JsonPropertyName($"{jsonPrefix}{name}");
            w.Property("public", member.RevisionType, $"{member.RevisionName}");
            w.AppendLine();
        }
    }

    #endregion Properties

    void Constructors()
    {
        w.Summary("For deserialization");
        w.AppendLine($"public {Class}() {{ }}");
        w.AppendLine();

        w.Summary("Create a reference before editing main instance");
        using var _ = w.AppendIndentBracket($"public {Class}({sourceClass} data)");

        foreach (var member in members)
        {
            //Source property
            string value = $"data.{member.Name}";

            switch (member.PropertyType)
            {
                case PropertyType.Value:
                    w.AppendLine($"{member.Name} = {value};");
                    break;

                case PropertyType.ValueNullable:
                    w.AppendLine($"{member.Name} = new() {{ {NullChanged} = {value} }};");
                    break;

                case PropertyType.Class:
                    if (w.Attribute.HandleUnexpectedNull == false)
                        w.Assert($"{value} != null");
                    w.AppendLine($"{member.Name} = {JsonClone}({value});");
                    break;

                case PropertyType.ClassNullable:
                    w.AppendLine($"{member.Name} = new() {{ {NullChanged} = {JsonClone}({value}) }};");
                    break;

                case PropertyType.Revision:
                    if (w.Attribute.HandleUnexpectedNull)
                    {
                        using (w.IfNoBracket($"{value} == null"))
                            w.AppendLine($"{member.Name} = null;");
                        using (w.ElseNoBracket())
                            w.AppendLine($"{member.RevisionName} = new({value});");
                    }
                    else
                    {
                        w.Assert($"{value} != null");
                        w.AppendLine($"{member.RevisionName} = new({value});");
                    }
                    break;

                case PropertyType.RevisionNullable:
                    using (w.IfNoBracket($"{value} == null"))
                        w.AppendLine($"{member.Name} = new() {{ {NullChanged} = null }};");
                    using (w.ElseNoBracket())
                        w.AppendLine($"{member.RevisionName} = new({value});");
                    break;

                default: throw new NotImplementedException();
            }
        }
    }

    #region ApplyTo

    const string ApplyToMethod = nameof(IDiff<>.ApplyTo);

    void ApplyTo()
    {
        w.Summary($"Apply changes to full instance");
        using var _ = w.Method("public", sourceClass, ApplyToMethod, $"{sourceClass}? from");

        w.AppendLine($"var to = {JsonClone}(from) ?? Activator.CreateInstance<{sourceClass}>();");
        foreach (var member in members)
        {
            if (member.IsDiffAlways)
            {
                ApplyTo_DiffAlways(member);
            }
            else
            {
                ApplyTo_Change(member);
                ApplyTo_Revision(member);
            }
        }
        w.AppendLine("return to;");
    }

    void ApplyTo_DiffAlways(MemberToGenerate member)
    {
        var value = member.PropertyType switch
        {
            PropertyType.Value => $"{member.Name}",
            PropertyType.ValueNullable => $"{member.Name}",
            PropertyType.Class => $"{JsonClone}({member.Name})",
            PropertyType.ClassNullable => $"{JsonClone}({member.Name})",
            PropertyType.Revision => $"{JsonClone}({member.Name})",
            PropertyType.RevisionNullable => $"{JsonClone}({member.Name})",
            _ => throw new NotImplementedException()
        };
        //No need to convert string? to string.
        if (member.Type.Name == "string")
            value = $"{member.Name}";

        //Always apply
        w.AppendLine($"to.{member.Name} = {value};");
    }

    void ApplyTo_Change(MemberToGenerate member)
    {
        var value = member.PropertyType switch
        {
            PropertyType.Value => $"{member.Name}.{nameof(Nullable<>.Value)}",
            PropertyType.ValueNullable => $"{member.Name}.{nameof(JsonNullableChanged<>.Changed)}",
            PropertyType.Class => $"{JsonClone}({member.Name})",
            PropertyType.ClassNullable => $"{JsonClone}({member.Name}.{nameof(JsonNullableChanged<>.Changed)})",
            PropertyType.Revision => $"{JsonClone}({member.Name})",
            PropertyType.RevisionNullable => $"{JsonClone}({member.Name}.{NullChanged})",
            _ => throw new NotImplementedException()
        };
        //No need to convert string? to string.
        if (member.Type.Name == "string")
            value = $"{member.Name}";

        using (w.IfNoBracket($"{member.Name} != null"))
            w.AppendLine($"to.{member.Name} = {value};");
    }

    void ApplyTo_Revision(MemberToGenerate member)
    {
        if (member.RevisionName == null)
            return;

        if (member.IsDiffAlways)
            throw new NotImplementedException();

        using (w.IfNoBracket($"{member.RevisionName} != null"))
            w.AppendLine($"to.{member.Name} = {member.RevisionName}.{ApplyToMethod}(to.{member.Name});");
    }

    #endregion ApplyTo

    void TrimIsUnchanged()
    {
        w.Summary($"Remove all properties matching in data.\n" +
            "Return true if ALL properties were trimmed");
        using var _ = w.Method("public", new FullName("bool"), nameof(IDiff<>.TrimIsUnchanged), $"{sourceClass} data");

        w.AppendLine($"var remaining = {members.Count(m => m.IsDiffAlways == false)};");
        var remainingSubtract = "remaining--;";
        foreach (var member in members)
        {
            //Don't test this, always changed
            if (member.IsDiffAlways)
                continue;

            switch (member.PropertyType)
            {
                case PropertyType.RevisionNullable:
                    using (w.If($"{member.Name} != null"))
                    {
                        w.Comment("Changed: null");
                        w.Assert($"{member.Name}.{NullChanged} == null");
                        using (w.If($"data.{member.Name} == null"))
                        {
                            w.AppendLine($"{member.Name} = null;");
                            w.AppendLine(remainingSubtract);
                        }
                    }
                    using (w.Else())
                    {
                        w.Comment("Revision");
                        using (w.If($"data.{member.Name} == null || {member.RevisionName}!.{nameof(IDiff<>.TrimIsUnchanged)}(data.{member.Name})"))
                        {
                            w.AppendLine($"{member.RevisionName} = null;");
                            w.AppendLine(remainingSubtract);
                        }
                    }
                    break;

                default:
                    var test = member.PropertyType switch
                    {
                        PropertyType.Value => $"{member.Name} == data.{member.Name}",
                        PropertyType.ValueNullable => $"{member.Name}!.{nameof(JsonNullableChanged<>.Changed)} == data.{member.Name}",
                        PropertyType.Class => $"{JsonCompare}({member.Name}, data.{member.Name})",
                        PropertyType.ClassNullable => $"{JsonCompare}({member.Name}!.{nameof(JsonNullableChanged<>.Changed)}, data.{member.Name})",
                        PropertyType.Revision => $"{member.RevisionName}!.{nameof(IDiff<>.TrimIsUnchanged)}(data.{member.Name})",
                        _ => throw new NotImplementedException(member.PropertyType.ToString())
                    };
                    using (w.If(test))
                    {
                        w.AppendLine($"{member.Name} = null;");
                        if (member.RevisionName != null)
                            w.AppendLine($"{member.RevisionName} = null;");
                        w.AppendLine(remainingSubtract);
                    }
                    break;
            }
        }

        w.AppendLine("return remaining <= 0;");
    }

}
