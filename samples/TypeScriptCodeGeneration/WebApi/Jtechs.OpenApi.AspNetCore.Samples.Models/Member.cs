using System.ComponentModel.DataAnnotations;

namespace Jtechs.OpenApi.AspNetCore.Samples.Models;

public record class Member
{
    public Guid Id { get; init; }

    public Name Name { get; init; } = default!;

    public MembershipLevel Level { get; init; }

    [Required, EmailAddress, RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
    public required string EmailAddress { get; init; } = default!;

    [Required, Range(18, 65)]
    public int Age { get; init; }

    public IEnumerable<SnsAccount> SnsAccounts { get; init; } = [];
}
