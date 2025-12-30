#nullable enable

using System.CodeDom.Compiler;
using System.Collections.Generic;
using Debug = System.Diagnostics.Debug;
using SilentOrbit.JsonDiff.Interfaces;
using SilentOrbit.JsonDiff.Tools;
using System.Text.Json.Serialization;

namespace SilentOrbit.JsonDiff.Demo;

public partial class TestRevClass : IDiffClass<TestRevClass,TestRevClass.Diff,TestRevClass.DiffGenerator>
{
    [GeneratedCode("SilentOrbit.JsonDiff", "0.1")]
    public partial class Diff : IDiff<TestRevClass>
    {
        #region Change Properties

        /// <summary>
        /// <see cref="TestRevClass.A"/>
        /// </summary>
        public int? A { get; set; }

        /// <summary>
        /// <see cref="TestRevClass.B"/>
        /// </summary>
        [JsonConverter(typeof(JsonNullableChangedConverter<int?>))]
        public JsonNullableChanged<int?>? B { get; set; }

        #endregion Change Properties


        #region Diff Properties "^..."

        #endregion Diff Properties "^..."


        /// <summary>
        /// For deserialization
        /// </summary>
        public Diff() { }

        /// <summary>
        /// Create a reference before editing main instance
        /// </summary>
        public Diff(TestRevClass data)
        {
            A = data.A;
            B = new() { Changed = data.B };
        }

        /// <summary>
        /// Remove all properties matching in data.
        /// Return true if ALL properties were trimmed
        /// </summary>
        public bool TrimIsUnchanged(TestRevClass data)
        {
            var remaining = 2;
            if (A == data.A)
            {
                A = null;
                remaining--;
            }
            if (B!.Changed == data.B)
            {
                B = null;
                remaining--;
            }
            return remaining <= 0;
        }

        /// <summary>
        /// Apply changes to full instance
        /// </summary>
        public TestRevClass ApplyTo(TestRevClass? from)
        {
            var to = JsonClone.Clone(from) ?? new();
            if (A != null)
                to.A = A.Value;
            if (B != null)
                to.B = B.Changed;
            return to;
        }
    }
}
