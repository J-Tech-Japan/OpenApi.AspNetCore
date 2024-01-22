using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Jtechs.OpenApi.AspNetCore;

public static class ICustomAttributeProviderExtensions
{
    public static string? GetDisplayName<T>(this T customAttributeProvider, bool inherit = false) where T : ICustomAttributeProvider =>
        customAttributeProvider.GetAttribute<DisplayNameAttribute>(inherit)?.DisplayName
        ?? customAttributeProvider.GetAttribute<DisplayAttribute>(inherit)?.Name;

    public static string? GetDescription<T>(this T customAttributeProvider, bool inherit = false) where T : ICustomAttributeProvider =>
        customAttributeProvider.GetAttribute<DescriptionAttribute>(inherit)?.Description
        ?? customAttributeProvider.GetAttribute<DisplayAttribute>(inherit)?.Description;

    public static T? GetAttribute<T>(this ICustomAttributeProvider p, bool inherit = false)
        where T : Attribute
    {
        var attributes = p.GetCustomAttributes(inherit);
        return attributes.FirstOrDefault(f => f.GetType() == typeof(T)) as T
            ?? attributes.FirstOrDefault(f => f.GetType().BaseType == typeof(T)) as T
            ?? attributes.FirstOrDefault(f => (f as T) is not null) as T;
    }
}
