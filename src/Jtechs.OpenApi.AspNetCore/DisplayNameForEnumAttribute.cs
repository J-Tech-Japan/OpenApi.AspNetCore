using System.ComponentModel;

namespace Jtechs.OpenApi.AspNetCore;

[AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field)]
public class DisplayNameForEnumAttribute(string displayName) : DisplayNameAttribute(displayName)
{ }
