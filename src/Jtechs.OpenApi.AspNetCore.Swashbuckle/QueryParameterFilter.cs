using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Jtechs.OpenApi.AspNetCore.Swashbuckle;

public class QueryParameterFilter : IParameterFilter
{
    public void Apply(OpenApiParameter parameter, ParameterFilterContext context)
    {
        if (parameter.In != ParameterLocation.Query)
            return;

        // Enum
        var enumTypeName = context.ParameterInfo.ParameterType switch
        {
            { IsEnum: true } type
                => type.Name
            ,
            { IsGenericType: true } type
                when type.GetGenericTypeDefinition() == typeof(Nullable<>)
                  && type.GetGenericArguments().SingleOrDefault()?.IsEnum == true
                => type.GetGenericArguments().Single().Name
            ,
            _ => null
        };
        parameter.Schema = enumTypeName is null ? parameter.Schema : new OpenApiSchema()
        {
            AllOf = [new OpenApiSchema()
            {
                Reference = new OpenApiReference()
                {
                    Id = enumTypeName,
                    Type = ReferenceType.Schema
                }
            }],
            Title = parameter.Schema.Title,
            Description = parameter.Schema.Description,
        };

        // Nullable & Required
        (parameter.Schema.Nullable, parameter.Required) = context switch
        {
            { PropertyInfo: { } propertyInfo } =>
                propertyInfo.IsNullable()
                ? (true, propertyInfo.GetAttribute<RequiredAttribute>() is not null)
                : (false, true)
            ,
            { ParameterInfo: { } parameterInfo } =>
                parameterInfo.IsNullable()
                ? (true, parameterInfo.GetAttribute<RequiredAttribute>() is not null)
                : (false, true)
            ,
            _ => (parameter.Schema.Nullable, parameter.Required)
        };
    }
}
