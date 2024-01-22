using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Jtechs.OpenApi.AspNetCore.Swashbuckle;

public class NullableTypeSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        schema.Nullable = context switch
        {
            { MemberInfo: { MemberType: MemberTypes.Property, DeclaringType: not null } mi }
                when mi.DeclaringType.GetProperty(mi.Name) is PropertyInfo propertyInfo
                => propertyInfo.IsNullable()
            ,
            { ParameterInfo: { } parameterInfo }
                => parameterInfo.IsNullable()
            ,
            _ => schema.Nullable
        };
    }
}
