using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public class DateTimeConverter : JsonConverter<long>
{
    public override long Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.GetInt64();
    }

    public override void Write(Utf8JsonWriter writer, long value, JsonSerializerOptions options)
    {
        var dateTime = DateTimeOffset.FromUnixTimeSeconds(value).ToString("yyyy-MM-ddTHH:mm:ss+00:00");
        writer.WriteStringValue(dateTime);
    }
}
