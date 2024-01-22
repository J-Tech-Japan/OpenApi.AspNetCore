using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

namespace Jtechs.OpenApi.AspNetCore.Swashbuckle;

public class RequiredReferenceTypeSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (context.ParameterInfo is not null
            || context.MemberInfo is not null
            || context.Type.IsEnum
            || schema.AllOf.Count > 0
            || schema.Properties.Count == 0)
            return;

        foreach (var property in schema.Properties)
        {
            if (schema.Required.Any(n => n == property.Key))
                continue;

            if (context.Type.GetProperties().SingleOrDefault(n =>
                    n.Name.Equals(property.Key, StringComparison.CurrentCultureIgnoreCase))
                    is not PropertyInfo propertyInfo
                || new NullabilityInfoContext().Create(propertyInfo).ReadState != NullabilityState.Nullable)
                schema.Required.Add(property.Key);
        }
    }
}
