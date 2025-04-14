using System.Text.Json;

namespace PaperWars.Utils;

public class SerializationHelper
{
    //private static IExtendedLogger Log => LogManager.GetCallerReflectionLogger(typeof(JsonSerializerHelper));
    public static T DeserializeJson<T>(string stringContent)
    {
        try
        {
            return JsonSerializer.Deserialize<T>(stringContent);
        }
        catch (JsonException ex)
        {
            //Log.Warn($"Failed to DeserializeJson JSON to type {typeof(T)}", ex);
            throw new InvalidOperationException($"Failed to deserialize JSON to type {typeof(T)}", ex);
        }
    }

    public static T DeserializeJsonWeb<T>(string obj)
    {
        try
        {
            return JsonSerializer.Deserialize<T>(obj, Web);
        }
        catch (Exception ex)
        {
           // Log.Warn($"Failed to DeserializeJsonWeb JSON to type {typeof(T)}", ex);
            throw new InvalidOperationException($"Failed to deserialize JSON to type {typeof(T)}", ex);
        }
    }

    public static string SerializeToJson<T>(T obj)
    {
        try
        {
            var json = JsonSerializer.Serialize(obj);

            return json;
        }
        catch (Exception ex)
        {
           // Log.Warn($"Failed to SerializeToJson JSON to type {typeof(T)}", ex);
            throw new InvalidOperationException($"Failed to serialize object of type {typeof(T)} to JSON", ex);
        }
    }

    public static string SerializeToCamelCaseJson<T>(T obj)
    {
        try
        {
            var json = JsonSerializer.Serialize(obj, CamelCase);

            return json;
        }
        catch (Exception ex)
        {
            //Log.Warn($"Failed to SerializeToCamelCaseJson JSON to type {typeof(T)}");
            throw new InvalidOperationException($"Failed to serialize object of type {typeof(T)} to JSON", ex);
        }
    }

    private static readonly JsonSerializerOptions Web = new(JsonSerializerDefaults.Web);

    private static readonly JsonSerializerOptions CamelCase = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };
}
