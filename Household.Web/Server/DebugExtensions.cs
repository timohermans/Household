using System.Text.Json;
using System.Text.Json.Serialization;

namespace Household.Web.Server;

public static class DebugExtensions
{
    public static string Dump(this object obj)
    {
        return JsonSerializer.Serialize(obj, new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve,
            WriteIndented = true,
        });
    }
}
