using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Jtechs.OpenApi.AspNetCore.Samples.Models;

[DisplayNameForEnum("Membership Level")]
[Description("The level of membership")]
public enum MembershipLevel
{
    [Display(Name = "Bronze Member", Description = "The lowest level of membership")]
    Bronze = 1,
    [Display(Name = "Silver Member", Description = "The middle level of membership")]
    Silver = 2,
    [Display(Name = "Gold Member", Description = "The second highest level of membership")]
    Gold = 3,
    [Display(Name = "Platinum Member", Description = "The highest level of membership")]
    Platinum = 4,
}
