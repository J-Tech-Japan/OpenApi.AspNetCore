using Jtechs.OpenApi.AspNetCore.Samples.Models;
using Jtechs.OpenApi.AspNetCore.Swashbuckle;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    // Add JtechsOpenApiFilters to support OpenAPI filters
    options.AddJtechsOpenApiFilters();
});

// Add JsonStringEnumConverter to support enum serialization
builder.Services.Configure<Microsoft.AspNetCore.Mvc.JsonOptions>(options =>
{
    options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
});
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var memberGroup = app.MapGroup("/Members").WithTags("Members");

memberGroup.MapGet("/",
    handler: ([AsParameters] MemberQueryParameter queryParameter) =>
    {
        return Results.Ok(new List<Member>());
    })
    .WithName("ListMembers")
    .Produces<IEnumerable<Member>>(StatusCodes.Status200OK);

memberGroup.MapGet("/{id}",
    handler: ([FromRoute] Guid id) =>
    {
        return Results.NotFound();
    })
    .WithName("GetMember")
    .Produces<Member>(StatusCodes.Status200OK)
    .Produces(StatusCodes.Status404NotFound);

memberGroup.MapPost("/",
    handler: ([FromBody] Member newMember) =>
    {
        return Results.Created($"/Members/{newMember.Id}", null);
    })
    .WithName("CreateMember")
    .Produces(StatusCodes.Status201Created);

memberGroup.MapPut("/{id}",
    handler: ([FromRoute] Guid id, [FromBody] Member existingMember) =>
    {
        return Results.Ok();
    })
    .WithName("UpdateMember")
    .Produces(StatusCodes.Status200OK);

memberGroup.MapDelete("/{id}",
    handler: ([FromRoute] Guid id) =>
    {
        return Results.NoContent();
    })
    .WithName("DeleteMember")
    .Produces(StatusCodes.Status204NoContent);

app.Run();
