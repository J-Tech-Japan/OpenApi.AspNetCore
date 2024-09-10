using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Jtechs.OpenApi.AspNetCore.Samples.Models;

public record class Name(
    [property: Required, MaxLength(30)]
    string LastName,

    [property: Required, MaxLength(30)]
    string FirstName,

    [property: MaxLength(30)]
    string? MiddleName = default
)
{
    [JsonIgnore]
    public string FullName => string.IsNullOrWhiteSpace(MiddleName)
        ? $"{LastName} {FirstName}"
        : $"{LastName} {MiddleName} {FirstName}";
}