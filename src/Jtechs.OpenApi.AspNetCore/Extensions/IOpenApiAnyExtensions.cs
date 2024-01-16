using Microsoft.OpenApi.Any;

namespace Jtechs.OpenApi.AspNetCore.Extensions;

public static class IOpenApiAnyExtensions
{
    public static OpenApiArray ToOpenApiArray(this IEnumerable<IOpenApiAny> items)
    {
        var array = new OpenApiArray();
        array.AddRange(items);
        return array;
    }
}
