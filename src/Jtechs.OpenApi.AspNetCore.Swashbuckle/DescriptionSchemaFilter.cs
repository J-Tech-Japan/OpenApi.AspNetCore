using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Jtechs.OpenApi.AspNetCore.Swashbuckle;

public class DescriptionSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        schema.Description = context switch
        {
            { ParameterInfo: { } pi } when pi.GetDescription() is string name => name
            ,
            { MemberInfo: { } mi } when mi.GetDescription() is string name => name
            ,
            { Type: { } type } when !schema.AllOf.Any() && type.GetDescription() is string name => name
            ,
            _ => schema.Description
        };
    }
}
