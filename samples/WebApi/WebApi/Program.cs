using Jtechs.OpenApi.AspNetCore.Swashbuckle;
using Microsoft.AspNetCore.Mvc;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSwaggerGen(options =>
{
    options.SchemaFilter<TitleAndDescriptionSchemaFilter>();
    options.SchemaFilter<EnumSchemaFilter>();
    options.UseAllOfToExtendReferenceSchemas();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapPost(
    "/setleague",
    ([FromBody] League league) =>
    {
        return league;
    });

app.MapGet(
        "/weatherforecast",
        ([FromQuery]League league) =>
        {
            var forecast = Enumerable.Range(1, 5)
                .Select(
                    index =>
                        new WeatherForecast(
                            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                            Random.Shared.Next(-20, 55),
                            summaries[Random.Shared.Next(summaries.Length)]
                        ))
                .ToArray();
            return forecast;
        })
    .WithName("GetWeatherForecast")
    .WithOpenApi();

app.Run();