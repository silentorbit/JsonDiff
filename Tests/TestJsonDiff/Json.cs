using System.Diagnostics;
using System.Text.Json;

namespace SilentOrbit.JsonDiff.Test;

static class Json
{
    static readonly JsonSerializerOptions options = new()
    {
        WriteIndented = true,
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingDefault
    };

    static Json()
    {
        options.RespectNullableAnnotations = true;
        options.UnmappedMemberHandling = System.Text.Json.Serialization.JsonUnmappedMemberHandling.Disallow;
    }

    public static string Serialize<T>(T data)
    {
        var json = JsonSerializer.Serialize(data, options);
        return json;
    }

    public static T Deserialize<T>(string json)
    {
        var data = JsonSerializer.Deserialize<T>(json, options)!;
        return data;
    }

    public static void AssertJSON<T>(T data, string expectedJSON)
    {
        var dataJson = Serialize<T>(data);
        Debug.Assert(expectedJSON == dataJson);
        Assert.AreEqual(expectedJSON, dataJson);
    }
}
