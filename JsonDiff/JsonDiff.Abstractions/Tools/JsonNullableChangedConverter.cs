using System.Text.Json;
using System.Text.Json.Serialization;

namespace SilentOrbit.JsonDiff.Tools;

public class JsonNullableChangedConverter<T> : JsonConverter<JsonNullableChanged<T>?>
{
    public override bool HandleNull => true;

    public override JsonNullableChanged<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
            return new JsonNullableChanged<T> { Changed = default! };

        return new JsonNullableChanged<T> { Changed = JsonSerializer.Deserialize<T>(ref reader, options)! };
    }

    public override void Write(Utf8JsonWriter writer, JsonNullableChanged<T>? value, JsonSerializerOptions options)
    {
        if (value == null)
            return;
        else if (value.Changed == null)
            writer.WriteNullValue();
        else
            JsonSerializer.Serialize<T>(writer, value.Changed, options);
    }
}
