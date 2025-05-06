using RestApiAnimals.Models;
using RestApiAnimals.Extensions;
using RestApiAnimals.ServiceLayer;
using Microsoft.AspNetCore.Mvc;
using RestApiAnimals.Filters;
using RestApiAnimals.DTOs;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMainServices();

var app = builder.Build();

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Errors");
}

// получение списка всех животных
app.MapGet("/api/animals", (IAnimalService service) => Results.Ok(service.GetAllAnimals()));

// получение информации о конкретном животном
app.MapGet("/api/animals/{id}", (string id, IAnimalService service) =>
{
    var animal = service.GetAnimalById(id);
    return animal != null
    ? TypedResults.Ok(animal)
    : Results.Problem(statusCode: 404);

}).AddEndpointFilter(ValidationHelper.ValidateId);

// добавление животного в словарь по id
app.MapPost("/api/animals/{id}", (string id, [FromBody] Animal animal, IAnimalService service) =>
{
    return service.AddAnimal(id, animal)
    ? TypedResults.Created($"/api/animals/{id}", animal)
    : Results.ValidationProblem(new Dictionary<string, string[]>
    {
        {"id", new string[] {"Animal with this id is already exists" } } 
    });

}).AddEndpointFilter(ValidationHelper.ValidateId)
  .WithParameterValidation(); // Использование библиотеки MinimalApis.Extensions (NuGet) - фильтр по атрибутам

// кормление выбранного по id животного
app.MapPost("/api/animals/{id}/feed", (string id, [FromBody] FeedDto feedDto, IAnimalService service) =>
{
    return service.FeedAnimal(id, feedDto.FeedAmount)
    ? TypedResults.Ok()
    : Results.Problem(statusCode: 404);

}).AddEndpointFilter(ValidationHelper.ValidateId)
  .WithParameterValidation(); // Использование библиотеки MinimalApis.Extensions (NuGet) - фильтр по атрибутам

// удаление животного
app.MapDelete("/api/animals/{id}", (string id, IAnimalService service) =>
{
    return service.DeleteAnimal(id)
    ? TypedResults.NoContent()
    : Results.Problem(statusCode: 404);

}).AddEndpointFilter(ValidationHelper.ValidateId);

app.Run();