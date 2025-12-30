using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SilentOrbit.JsonDiff.Demo;

static class Helpers
{
    public static void AssertDiff(DemoClass v1, DemoClass v2, string jsonDiff)
    {
        var diff = v2.CreateReferenceDiff();
        diff.TrimIsUnchanged(v1);
        JsonAssert(diff, jsonDiff);
    }

    /// <summary>
    /// Verify the serialized version of an object.
    /// </summary>
    public static void JsonAssert<T>(T data, string expectedJSON)
    {
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions
        {
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault
        });
        Debug.Assert(json == expectedJSON);
    }
}
