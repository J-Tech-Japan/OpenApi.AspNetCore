namespace Jtechs.OpenApi.AspNetCore.Samples.Models;

public record class MemberQueryParameter(
    MembershipLevel? Level,
    string? NameSubString,
    int? Age
);