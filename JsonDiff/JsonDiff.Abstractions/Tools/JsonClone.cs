using System.Text.Json;

namespace SilentOrbit.JsonDiff.Tools;

public static class JsonClone
{
#if NETSTANDARD2_0_OR_GREATER && !NETSTANDARD2_0
    //NETSTANDARD 2.1
    [return: NotNullIfNotNull(nameof(source))]
    public static T? Clone<T>(T? source)
    {
        if (source is null)
            return default;

        var json = JsonSerializer.Serialize(source);
        var obj = JsonSerializer.Deserialize<T>(json);
        return obj;
    }
#else
    public static T Clone<T>(T? source)
    {
        if (source is null)
            return default!;

        var json = JsonSerializer.Serialize(source);
        var obj = JsonSerializer.Deserialize<T>(json);
        return obj!;
    }
#endif

    public static bool Compare<T>(T? a, T? b)
        where T : class
    {
        if (a is null && b is null)
            return true;
        if (a is null || b is null)
            return false;
        var jsonA = JsonSerializer.Serialize(a);
        var jsonB = JsonSerializer.Serialize(b);
        return jsonA == jsonB;
    }
}
