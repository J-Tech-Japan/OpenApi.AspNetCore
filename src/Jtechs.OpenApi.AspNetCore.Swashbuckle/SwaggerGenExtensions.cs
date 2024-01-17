using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Jtechs.OpenApi.AspNetCore.Swashbuckle;

public static class SwaggerGenExtensions
{
    public static void AddJtechsSchemaFilters(this SwaggerGenOptions options)
    {
        options.SchemaFilter<TitleAndDescriptionSchemaFilter>();
        options.SchemaFilter<EnumSchemaFilter>();
        options.UseAllOfToExtendReferenceSchemas();
    }
}
