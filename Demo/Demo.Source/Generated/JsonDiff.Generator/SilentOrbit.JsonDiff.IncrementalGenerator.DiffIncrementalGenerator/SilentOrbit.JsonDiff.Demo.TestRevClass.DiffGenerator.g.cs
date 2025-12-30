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
    /// <summary>
    /// Generate Rev on demand
    /// </summary>
    [GeneratedCode("SilentOrbit.JsonDiff", "0.1")]
    public partial class DiffGenerator : DiffGeneratorBase<TestRevClass,TestRevClass.Diff>
    {
        public static implicit operator DiffGenerator(TestRevClass data) => new(data);
        public DiffGenerator(TestRevClass data) : base(data)
        {
        }
        public int A
        {
            get => Data.A;
            set
            {
                // Not changed
                if (Data.A == value)
                    return;
                // Store old value first time modified
                Rev.A ??= Data.A;
                // Store new value
                Data.A = value;
            }
        }
        public int? B
        {
            get => Data.B;
            set
            {
                // Not changed
                if (Data.B == value)
                    return;
                // Store old value first time modified
                Rev.B ??= new() { Changed = Data.B };
                // Store new value
                Data.B = value;
            }
        }
    }
}
