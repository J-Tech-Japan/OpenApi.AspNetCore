using Jtechs.OpenApi.AspNetCore.Extensions;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Jtechs.OpenApi.AspNetCore.Swashbuckle;

public class EnumSchemaFilter : ISchemaFilter
{
    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        if (!context.Type.IsEnum || schema.AllOf.Count > 0)
            return;

        var enms = Enum.GetValues(context.Type).Cast<Enum>()
            .Select(enm => new
            {
                Member = enm,
                MemberInfo = enm.GetType().GetMember(enm.ToString())?.FirstOrDefault(),
            })
            .Select(enm => new
            {
                Value = Convert.ToInt32(enm.Member),
                VarName = enm.Member.ToString(),
                DisplayName = enm.MemberInfo?.GetCustomAttribute<DisplayNameAttribute>()?.DisplayName
                    ?? enm.MemberInfo?.GetCustomAttribute<DisplayAttribute>()?.Name
                    ?? null,
                Description = enm.MemberInfo?.GetCustomAttribute<DescriptionAttribute>()?.Description
                    ?? enm.MemberInfo?.GetCustomAttribute<DisplayAttribute>()?.Description
                    ?? null,
            });

        schema.Enum = schema.Type == "string"
            ? enms.Select(n => new OpenApiString(n.VarName)).ToOpenApiArray()
            : enms.Select(n => new OpenApiInteger(n.Value)).ToOpenApiArray();
        schema.Extensions.Add("x-enum-values", enms.Select(n => new OpenApiInteger(n.Value)).ToOpenApiArray());
        schema.Extensions.Add("x-enum-varnames", enms.Select(n => new OpenApiString(n.VarName)).ToOpenApiArray());
        schema.Extensions.Add("x-enum-titles", enms.Select(n => new OpenApiString(n.DisplayName)).ToOpenApiArray());
        schema.Extensions.Add("x-enum-descriptions", enms.Select(n => new OpenApiString(n.Description)).ToOpenApiArray());
    }
}
