#nullable enable

using System.CodeDom.Compiler;
using System.Collections.Generic;
using Debug = System.Diagnostics.Debug;
using SilentOrbit.JsonDiff.Interfaces;
using SilentOrbit.JsonDiff.Tools;
using System.Text.Json.Serialization;

namespace SilentOrbit.JsonDiff.Demo;

public partial class TestNullHandled : IDiffClass<TestNullHandled,TestNullHandled.Diff,TestNullHandled.DiffGenerator>
{
    /// <summary>
    /// Generate Rev on demand
    /// </summary>
    [GeneratedCode("SilentOrbit.JsonDiff", "0.1")]
    public partial class DiffGenerator : DiffGeneratorBase<TestNullHandled,TestNullHandled.Diff>
    {
        public static implicit operator DiffGenerator(TestNullHandled data) => new(data);
        public DiffGenerator(TestNullHandled data) : base(data)
        {
        }
        public string MyString
        {
            get => Data.MyString;
            set
            {
                // Not changed
                if (Data.MyString == value)
                    return;
                // Store old value first time modified
                Rev.MyString ??= Data.MyString;
                // Store new value
                Data.MyString = value;
            }
        }
        public SilentOrbit.JsonDiff.Demo.TestRevClass.DiffGenerator MyRevClass
        {
            get
            {
                // Existing generator
                if (field != null)
                    return field;
                // Create a generator
                field = new(Data.MyRevClass);
                Rev.MyRevClass_Diff = field.Rev;
                return field;
            }
            /// <summary>
            /// Assume the generator is from implicit cast
            /// </summary>
            set
            {
                // Same generator
                if (field == value)
                    return;
                throw new NotImplementedException();
            }
        }
        public TestRevClass MyFullRevClass
        {
            get
            {
                // Store old value first time accessed
                Rev.MyFullRevClass ??= JsonClone.Clone(Data.MyFullRevClass);
                // Store new value
                return Data.MyFullRevClass;
            }
            set
            {
                // Not changed
                if (Data.MyFullRevClass == value)
                    return;
                // Store old value first time modified
                Rev.MyFullRevClass ??= JsonClone.Clone(Data.MyFullRevClass);
                // Store new value
                Data.MyFullRevClass = value;
            }
        }
        public TestSimpleClass MySimpleClass
        {
            get
            {
                // Store old value first time accessed
                Rev.MySimpleClass ??= JsonClone.Clone(Data.MySimpleClass);
                // Store new value
                return Data.MySimpleClass;
            }
            set
            {
                // Not changed
                if (Data.MySimpleClass == value)
                    return;
                // Store old value first time modified
                Rev.MySimpleClass ??= JsonClone.Clone(Data.MySimpleClass);
                // Store new value
                Data.MySimpleClass = value;
            }
        }
    }
}
