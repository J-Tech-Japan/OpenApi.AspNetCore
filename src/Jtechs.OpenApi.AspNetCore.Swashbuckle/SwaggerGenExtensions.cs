using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Jtechs.OpenApi.AspNetCore.Swashbuckle;

public static class SwaggerGenExtensions
{
    public static void AddJtechsOpenApiFilters(this SwaggerGenOptions options)
    {
        options.UseAllOfToExtendReferenceSchemas();
        options.SchemaFilter<EnumSchemaFilter>();
        options.SchemaFilter<NullableTypeSchemaFilter>();
        options.SchemaFilter<RequiredReferenceTypeSchemaFilter>();
        options.SchemaFilter<TitleSchemaFilter>();
        options.SchemaFilter<DescriptionSchemaFilter>();
        options.ParameterFilter<QueryParameterFilter>();
    }
}
