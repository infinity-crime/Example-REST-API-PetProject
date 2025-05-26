using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestApiAnimals.DataAccess.Context;
using RestApiAnimals.Domain;
using RestApiAnimals.DTOs;
using RestApiAnimals.Extensions;
using RestApiAnimals.Filters;
using RestApiAnimals.ServiceLayer;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMainServices();

builder.Configuration.AddUserSecrets("secrets.json"); // for the DB connection string

#region Connect Database
var connectionString = builder.Configuration
    .GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});
#endregion

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

#region Configuring Exception Handler
/* If an error occurs when filling the SpeciesType field in the POST method, 
 * it will be an exception at the Middleware level. Since it will not reach the endpoint,
 * we need to handle it there (there is no point in wrapping the code in try/catch) */
app.UseExceptionHandler(exceptionHandlerApp =>
{
    exceptionHandlerApp.Run(async context =>
    {
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        context.Response.ContentType = "application/problem+json";

        await context.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Title = "Invalid animal type",
            Detail = "Unknown SpeciesType. Valid values: Lion, Elephant, Penguin",
            Status = StatusCodes.Status400BadRequest
        });
    });
});
#endregion

#region Endpoints
app.MapGet("/api/animals/all", async (IAnimalService service) =>
{
    return Results.Ok(await service.GetAllAnimalsAsync());
})
    .WithTags("Animals GET");

app.MapGet("/api/animals/{id}", async ([FromRoute] string id, IAnimalService service) =>
{
    var animal = await service.GetAnimalByIdAsync(id);
    return animal != null
    ? TypedResults.Ok(animal)
    : Results.ValidationProblem(new Dictionary<string, string[]>
    {
        {"id", new[] { "Unknown id!" } }
    });
})
    .AddEndpointFilter(ValidationHelper.ValidateId)
    .WithTags("Animals GET");

app.MapPost("/api/animals", async ([FromBody] AnimalDto animal, IAnimalService service) =>
{
    return await service.AddAnimalAsync(animal)
    ? TypedResults.Created($"/api/animals", animal)
    : Results.ValidationProblem(new Dictionary<string, string[]>
    {
        {"fields", new[] { "The fields are filled in incorrectly" } }
    });
})
    .WithParameterValidation()
    .WithTags("Animals POST");

app.MapPut("/api/animals/feed/{id}", async ([FromRoute] string id, [FromBody] FeedDto feedDto, IAnimalService service) =>
{
    return await service.FeedAnimalAsync(id, feedDto.FeedAmount)
    ? TypedResults.Ok()
    : Results.ValidationProblem(new Dictionary<string, string[]>
    {
        {"id", new[] { "Unknown id!" } }
    });
})
    .AddEndpointFilter(ValidationHelper.ValidateId)
    .WithParameterValidation()
    .WithTags("Animals PUT");

app.MapDelete("/api/animals/delete/{id}", async ([FromRoute] string id, IAnimalService service) =>
{
    return await service.DeleteAnimalAsync(id)
    ? TypedResults.NoContent()
    : Results.ValidationProblem(new Dictionary<string, string[]>
    {
        {"id", new[] { "Unknown id!" } }
    });
})
    .AddEndpointFilter(ValidationHelper.ValidateId)
    .WithTags("Animals DELETE");
#endregion

app.Run();