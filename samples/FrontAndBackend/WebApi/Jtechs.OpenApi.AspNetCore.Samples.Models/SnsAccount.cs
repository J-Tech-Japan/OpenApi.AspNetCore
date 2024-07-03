using System.ComponentModel.DataAnnotations;

namespace Jtechs.OpenApi.AspNetCore.Samples.Models;

public record class SnsAccount(
    SnsService SnsService,

    [property: Required, MaxLength(64)]
    string Account
);