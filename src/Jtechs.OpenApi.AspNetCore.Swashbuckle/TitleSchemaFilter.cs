using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Jtechs.OpenApi.AspNetCore.Swashbuckle;

public class TitleSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        schema.Title = context switch
        {
            { ParameterInfo: { } pi } when pi.GetDisplayName() is string name => name
            ,
            { MemberInfo: { } mi } when mi.GetDisplayName() is string name => name
            ,
            { Type: { } type } when !schema.AllOf.Any() && type.GetDisplayName() is string name => name
            ,
            _ => schema.Title
        };
    }
}
