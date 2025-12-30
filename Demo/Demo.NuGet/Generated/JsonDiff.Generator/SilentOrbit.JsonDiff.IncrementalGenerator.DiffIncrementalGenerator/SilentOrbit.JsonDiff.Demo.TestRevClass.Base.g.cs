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
    /// Create a full copy as a delta.
    /// Use with TrimIsUnchanged
    /// </summary>
    public Diff CreateReferenceDiff() => new(this);

    /// <summary>
    /// Create a generator that starts with an empty Diff and update it as changes are made to this instance.
    /// </summary>
    public DiffGenerator CreateDiffGenerator() => new(this);

}
