namespace SilentOrbit.JsonDiff.Generator;

class DiffGeneratorClassGenerator(DiffToGenerate spec) : BaseGenerator(spec)
{
    internal const string Class = "DiffGenerator";
    internal const string CreateSummary = $"Create a generator that starts with an empty {DiffClassGenerator.Class} and update it as changes are made to this instance.";
    internal const string Create = nameof(IDiffClass<,,>.CreateDiffGenerator);

    const string RevProperty = nameof(DiffGeneratorBase<,>.Rev);
    const string DataProperty = nameof(DiffGeneratorBase<,>.Data);

    protected override void Generate()
    {
        //class RevGenerator
        w.Summary("Generate Rev on demand");
        using (w.Class("public partial",
            classname: new(Class),
            extends: $"{nameof(DiffGeneratorBase<,>)}<{sourceClass},{sourceClass}.{DiffClassGenerator.Class}>",
            generatedCodeAttribute: true
            ))
        {
            //Implicit cast
            w.AppendLine($"public static implicit operator {Class}({sourceClass} data) => new(data);");

            Constructor();

            GeneratorProperties();
        }
    }

    void Constructor()
    {
        using (w.AppendIndentBracket($"public {Class}({sourceClass} data) : base(data)"))
        {
            foreach (var member in members)
            {
                if (member.IsDiffAlways)
                {
                    w.AppendLine($"{RevProperty}.{member.Name} = data.{member.Name};");
                }
            }
        }
    }

    void GeneratorProperties()
    {
        foreach (var member in members)
        {
            //Property

            var propertyType = member.Type;
            switch (member.PropertyType)
            {
                case PropertyType.Revision:
                    propertyType = new FullName($"{member.Class}.{Class}");
                    break;
                case PropertyType.RevisionNullable:
                    propertyType = new FullName($"{member.Class}.{Class}?");
                    break;
            }

            using (w.AppendIndentBracket($"public {propertyType} {member.Name}"))
            {
                PropertyGetSet(member);
            }
        }
    }

    void PropertyGetSet(MemberToGenerate member)
    {
        if (member.IsDiffAlways)
        {
            w.AppendLine($"get => {DataProperty}.{member.Name};");
            w.AppendLine($"set => {DataProperty}.{member.Name} = value;");
            return;
        }

        switch (member.PropertyType)
        {
            case PropertyType.Value:
                w.AppendLine($"get => {DataProperty}.{member.Name};");
                using (w.AppendIndentBracket("set"))
                {
                    w.Comment("Not changed");
                    using (w.IfNoBracket($"{DataProperty}.{member.Name} == value"))
                        w.Return();

                    w.Comment("Store old value first time modified");
                    w.AppendLine($"{RevProperty}.{member.Name} ??= {DataProperty}.{member.Name};");

                    w.Comment("Store new value");
                    w.AppendLine($"{DataProperty}.{member.Name} = value;");
                }
                break;

            case PropertyType.ValueNullable:
                w.AppendLine($"get => {DataProperty}.{member.Name};");
                using (w.AppendIndentBracket("set"))
                {
                    w.Comment("Not changed");
                    using (w.IfNoBracket($"{DataProperty}.{member.Name} == value"))
                        w.Return();

                    w.Comment("Store old value first time modified");
                    w.AppendLine($"{RevProperty}.{member.Name} ??= new() {{ {nameof(JsonNullableChanged<>.Changed)} = {DataProperty}.{member.Name} }};");

                    w.Comment("Store new value");
                    w.AppendLine($"{DataProperty}.{member.Name} = value;");
                }
                break;

            case PropertyType.Class:
                using (w.AppendIndentBracket("get"))
                {
                    w.Comment("Store old value first time accessed");
                    w.AppendLine($"{RevProperty}.{member.Name} ??= {JsonClone}({DataProperty}.{member.Name});");

                    w.Comment("Store new value");
                    w.Return($"{DataProperty}.{member.Name}");
                }
                using (w.AppendIndentBracket("set"))
                {
                    w.Comment("Not changed");
                    using (w.IfNoBracket($"{DataProperty}.{member.Name} == value"))
                        w.Return();

                    w.Comment("Store old value first time modified");
                    w.AppendLine($"{RevProperty}.{member.Name} ??= {JsonClone}({DataProperty}.{member.Name});");

                    w.Comment("Store new value");
                    w.AppendLine($"{DataProperty}.{member.Name} = value;");
                }
                break;

            case PropertyType.ClassNullable:
                using (w.AppendIndentBracket("get"))
                {
                    w.Comment("Store old value first time accessed");
                    w.AppendLine($"{RevProperty}.{member.Name} ??= new() {{ {NullChanged} = {JsonClone}({DataProperty}.{member.Name}) }};");

                    w.Return($"{DataProperty}.{member.Name}");
                }
                using (w.AppendIndentBracket("set"))
                {
                    w.Comment("Not changed");
                    using (w.IfNoBracket($"{DataProperty}.{member.Name} == value"))
                        w.Return();

                    w.Comment("Store old value first time modified");
                    w.AppendLine($"{RevProperty}.{member.Name} ??= new() {{ {NullChanged} = {JsonClone}({DataProperty}.{member.Name}) }};");

                    w.Comment("Store new value");
                    w.AppendLine($"{DataProperty}.{member.Name} = value;");
                }
                break;

            case PropertyType.Revision:
                //Get
                using (w.AppendIndentBracket("get"))
                {
                    w.Assert($"{DataProperty}.{member.Name} != null");

                    w.Comment("Existing generator");
                    using (w.IfNoBracket($"field != null"))
                        w.Return("field");

                    w.Comment("Create a generator");
                    w.AppendLine($"field = new({DataProperty}.{member.Name});");
                    w.AppendLine($"{RevProperty}.{member.RevisionName} = field.{RevProperty};");
                    w.Return("field");
                }
                //Set
                w.Summary("Assume the generator is from implicit cast");
                using (w.AppendIndentBracket("set"))
                {
                    //Here it is the generator we track
                    w.Comment("Same generator");
                    using (w.IfNoBracket($"field == value"))
                        w.Return();

                    w.Throw<NotImplementedException>();
                }
                break;

            case PropertyType.RevisionNullable:
                //Get
                using (w.AppendIndentBracket("get"))
                {
                    w.Comment("Null value => null generator");
                    using (w.IfNoBracket($"{DataProperty}.{member.Name} == null"))
                        w.Return("null");

                    w.Comment("Existing generator");
                    using (w.IfNoBracket($"field != null"))
                        w.Return("field");

                    w.Comment("Create a generator");
                    w.AppendLine($"field = new({DataProperty}.{member.Name});");
                    w.AppendLine($"{RevProperty}.{member.RevisionName} = field.{RevProperty};");
                    w.Return("field");
                }
                //Set
                w.Summary("Assume the generator is from implicit cast");
                using (w.AppendIndentBracket("set"))
                {
                    //Here it is the generator we track
                    w.Comment("Same generator");
                    using (w.IfNoBracket($"field == value"))
                        w.Return();
                    using (w.IfNoBracket("field != null"))
                        w.Throw<NotImplementedException>("Generator already created");

                    //No generator set, create a new one
                    using (w.If("value == null"))
                    {
                        //Set to null

                        //Already null
                        using (w.IfNoBracket($"{DataProperty}.{member.Name} == null"))
                            w.Return();

                        //TODO: Track entire previous value
                        //TODO: Create new generator
                        w.Throw<NotImplementedException>();
                    }
                    using (w.Else())
                    {
                        //Set to new instance
                        //TODO: Track entire previous value
                        //TODO: Create new generator
                        w.Throw<NotImplementedException>();
                    }
                    w.Throw<NotImplementedException>();
                }
                break;

            default:
                w.Error("TODO get;set;");
                break;
        }
    }
}
