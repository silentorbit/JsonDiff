namespace SilentOrbit.JsonDiff.CodeTools;

/// <summary>
/// Support generating C# code and parsing namespaces.
/// </summary>
class SourceWriter
{
    public JsonDiffClassAttribute Attribute { get; }

    public readonly StringBuilder sb = new();

    public readonly TypeScope Scope = new();

    /// <summary>
    /// Return generated code as string.
    /// </summary>
    public override string ToString()
    {
        return sb.ToString();
    }

    string? ns;

    public SourceWriter(DiffToGenerate spec)
    {
        //namespace
        ns = spec.SourceType.Namespace!;
        Scope.Add(ns);

        Attribute = spec.Attribute;

        sb.AppendLine("#nullable enable");
        sb.AppendLine();

        Using<System.CodeDom.Compiler.GeneratedCodeAttribute>();
    }

    /// <summary>
    /// Only uses the namespace of the specified type.
    /// </summary>
    public void Using<T>()
    {
        Using(typeof(T).Namespace);
    }

    public void Using(string? usingNamespace)
    {
        if (usingNamespace == null)
            return;

        if (!usingNamespace.Contains(" ") && !usingNamespace.Contains("="))
            Scope.Add(usingNamespace);

        sb.AppendLine($"using {usingNamespace};");
    }

    public IDisposable Class(string prefix, FullName classname, string? args = null, string? extends = null, bool generatedCodeAttribute = false)
    {
        if (ns != null)
        {
            sb.AppendLine();
            sb.AppendLine($"namespace {ns};");
            sb.AppendLine();
            ns = null;
        }

        if (classname.Namespace != null)
            Scope.Add(classname.Namespace);

        if (args != null)
            args = $"({args})";
        if (extends != null)
            extends = $" : {extends}";

        if (generatedCodeAttribute)
            AppendLine($"""[GeneratedCode("SilentOrbit.JsonDiff", "0.1")]""");
        AppendLine($"{prefix} class {classname.Name}{args}{extends}");

        AppendLine("{");
        return new UsingWriter(this, "}");
    }

    const string s4 = "    ";

    string indent = "";

    public void Indent(string? value = null)
    {
        if (value != null)
            AppendLine(value);
        indent += s4;
    }

    public void Outdent(string? line)
    {
        indent = indent.Substring(s4.Length);
        if (line != null)
            AppendLine(line);
    }

    public void AppendLine(string? line = null)
    {
        if (line == null)
        {
            sb.AppendLine();
            return;
        }

        sb.Append(indent).AppendLine(line);
    }

    /// <summary>
    /// Either a <see cref="Debug.Assert(bool)"/>
    /// or a <see cref="NotImplementedException"/>.
    /// </summary>
    public void Assert(string test, string? message = null)
    {
        switch (Attribute.AssertLevel)
        {
            case Attributes.AssertLevel.None:
                break;

            case AssertLevel.Debug:
                DebugAssert(test, message);
                break;

            case AssertLevel.Exception:
                using (IfNoBracket($"({test}) == false"))
                    Throw<NotImplementedException>(message: message);
                break;
        }
    }

    public void DebugAssert(string test, string? message = null)
    {
        if (message == null)
            AppendLine($"Debug.Assert({test});");
        else
        {
            AppendLine($@"Debug.Assert({test}, ""{message}"");");
        }
    }

    public void Statement(string line)
    {
        sb.Append(indent).Append(line).AppendLine(";");
    }

    public void Return(string? value = null)
    {
        if (value == null)
            AppendLine($"return;");
        else
            AppendLine($"return {value};");
    }

    public void Throw<T>(string? message = null, string? args = null)
        where T : Exception
    {
        var type = typeof(T);

        if (message != null)
        {
            if (args != null)
                throw new NotSupportedException("Can't combine args and message");
            args = $@"""{message}""";
        }
        AppendLine($"throw new {type.Name}({args});");
    }

    public void Error(string line)
    {
        AppendLine($"#error {line}");
    }

    public IDisposable AppendIndentBracket(string firstLine, string? lastLine = null)
    {
        AppendLine(firstLine);
        AppendLine("{");
        return new UsingWriter(this, $"}}{lastLine}");
    }

    public IDisposable If(string test)
    {
        return AppendIndentBracket($"if ({test})");
    }
    public IDisposable IfNoBracket(string test)
    {
        AppendLine($"if ({test})");
        return new UsingWriter(this);
    }

    public IDisposable Else()
    {
        return AppendIndentBracket($"else");
    }
    public IDisposable ElseNoBracket()
    {
        AppendLine($"else");
        return new UsingWriter(this);
    }

    public IDisposable Method(string prefix, FullName type, string name, string args)
    {
        return AppendIndentBracket($"{prefix} {Scope.Trim(type)} {name}({args})");
    }

    public IDisposable Region(string line)
    {
        AppendLine($"#region {line}\r\n");
        return new UsingWriter(this, $"#endregion {line}\r\n", indent: false);
    }

    public void Property(string prefix, string type, string name)
    {
        AppendLine($"{prefix} {type} {name} {{ get; set; }}");
    }

    public void Comment(string c)
    {
        AppendLine($"// {c}");
    }

    public void Obsolete(string c)
    {
#if !DEBUGx
        AppendLine($"[Obsolete(\"{c}\")]");
#endif
    }

    public void JsonConverter(string? type)
    {
        if (type == null)
            return;
        AppendLine($"[{TrimAttribute(nameof(JsonConverterAttribute))}(typeof({type}))]");
    }

    public void JsonPropertyName(string? name, string? codeName = null)
    {
        if (name == null || name == codeName)
            return;
        AppendLine($"[{TrimAttribute(nameof(JsonPropertyNameAttribute))}(\"{name}\")]");
    }

    static string TrimAttribute(string attributeType)
    {
        if (attributeType.EndsWith("Attribute") == false)
            throw new ArgumentException("type must end in Attribute");

        return attributeType.Substring(0, attributeType.Length - "Attribute".Length);
    }

    /// <summary>
    /// Write a XML comment summary like this one.
    /// </summary>
    public void Summary(string summary)
    {
        var lines = summary.Trim('\n', '\r', ' ', '\t').Split('\n', '\r');
        AppendLine($"/// <summary>");
        foreach (var line in lines)
            AppendLine($"/// {line}");
        AppendLine($"/// </summary>");
    }

}
