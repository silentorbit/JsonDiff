#nullable enable

using System.CodeDom.Compiler;
using System.Collections.Generic;
using Debug = System.Diagnostics.Debug;
using SilentOrbit.JsonDiff.Interfaces;
using SilentOrbit.JsonDiff.Tools;
using System.Text.Json.Serialization;

namespace SilentOrbit.JsonDiff.Demo;

public partial class TestNullUnhandled : IDiffClass<TestNullUnhandled,TestNullUnhandled.Diff,TestNullUnhandled.DiffGenerator>
{
    [GeneratedCode("SilentOrbit.JsonDiff", "0.1")]
    public partial class Diff : IDiff<TestNullUnhandled>
    {
        #region Change Properties

        /// <summary>
        /// <see cref="TestNullUnhandled.MyString"/>
        /// </summary>
        public string? MyString { get; set; }

        /// <summary>
        /// <see cref="TestNullUnhandled.MyRevClass"/>
        /// </summary>
        public SilentOrbit.JsonDiff.Demo.TestRevClass? MyRevClass { get; set; }

        /// <summary>
        /// <see cref="TestNullUnhandled.MyFullRevClass"/>
        /// </summary>
        public SilentOrbit.JsonDiff.Demo.TestRevClass? MyFullRevClass { get; set; }

        /// <summary>
        /// <see cref="TestNullUnhandled.MySimpleClass"/>
        /// </summary>
        public SilentOrbit.JsonDiff.Demo.TestSimpleClass? MySimpleClass { get; set; }

        #endregion Change Properties


        #region Diff Properties "^..."

        /// <summary>
        /// <see cref="TestNullUnhandled.MyRevClass"/>
        /// </summary>
        [JsonPropertyName("^MyRevClass")]
        public SilentOrbit.JsonDiff.Demo.TestRevClass.Diff? MyRevClass_Diff { get; set; }

        #endregion Diff Properties "^..."


        /// <summary>
        /// For deserialization
        /// </summary>
        public Diff() { }

        /// <summary>
        /// Create a reference before editing main instance
        /// </summary>
        public Diff(TestNullUnhandled data)
        {
            MyString = data.MyString;
            MyRevClass_Diff = new(data.MyRevClass);
            MyFullRevClass = JsonClone.Clone(data.MyFullRevClass);
            MySimpleClass = JsonClone.Clone(data.MySimpleClass);
        }

        /// <summary>
        /// Remove all properties matching in data.
        /// Return true if ALL properties were trimmed
        /// </summary>
        public bool TrimIsUnchanged(TestNullUnhandled data)
        {
            var remaining = 4;
            if (MyString == data.MyString)
            {
                MyString = null;
                remaining--;
            }
            if (MyRevClass_Diff!.TrimIsUnchanged(data.MyRevClass))
            {
                MyRevClass = null;
                MyRevClass_Diff = null;
                remaining--;
            }
            if (JsonClone.Compare(MyFullRevClass, data.MyFullRevClass))
            {
                MyFullRevClass = null;
                remaining--;
            }
            if (JsonClone.Compare(MySimpleClass, data.MySimpleClass))
            {
                MySimpleClass = null;
                remaining--;
            }
            return remaining <= 0;
        }

        /// <summary>
        /// Apply changes to full instance
        /// </summary>
        public TestNullUnhandled ApplyTo(TestNullUnhandled? from)
        {
            var to = JsonClone.Clone(from) ?? new();
            if (MyString != null)
                to.MyString = MyString;
            if (MyRevClass != null)
                to.MyRevClass = JsonClone.Clone(MyRevClass);
            if (MyRevClass_Diff != null)
                to.MyRevClass = MyRevClass_Diff.ApplyTo(to.MyRevClass);
            if (MyFullRevClass != null)
                to.MyFullRevClass = JsonClone.Clone(MyFullRevClass);
            if (MySimpleClass != null)
                to.MySimpleClass = JsonClone.Clone(MySimpleClass);
            return to;
        }
    }
}
