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

// ��������� ������ ���� ��������
app.MapGet("/api/animals", (IAnimalService service) => Results.Ok(service.GetAllAnimals()));

// ��������� ���������� � ���������� ��������
app.MapGet("/api/animals/{id}", (string id, IAnimalService service) =>
{
    var animal = service.GetAnimalById(id);
    return animal != null
    ? TypedResults.Ok(animal)
    : Results.Problem(statusCode: 404);

}).AddEndpointFilter(ValidationHelper.ValidateId);

// ���������� ��������� � ������� �� id
app.MapPost("/api/animals/{id}", (string id, [FromBody] Animal animal, IAnimalService service) =>
{
    return service.AddAnimal(id, animal)
    ? TypedResults.Created($"/api/animals/{id}", animal)
    : Results.ValidationProblem(new Dictionary<string, string[]>
    {
        {"id", new string[] {"Animal with this id is already exists" } } 
    });

}).AddEndpointFilter(ValidationHelper.ValidateId)
  .WithParameterValidation(); // ������������� ���������� MinimalApis.Extensions (NuGet) - ������ �� ���������

// ��������� ���������� �� id ���������
app.MapPost("/api/animals/{id}/feed", (string id, [FromBody] FeedDto feedDto, IAnimalService service) =>
{
    return service.FeedAnimal(id, feedDto.FeedAmount)
    ? TypedResults.Ok()
    : Results.Problem(statusCode: 404);

}).AddEndpointFilter(ValidationHelper.ValidateId)
  .WithParameterValidation(); // ������������� ���������� MinimalApis.Extensions (NuGet) - ������ �� ���������

// �������� ���������
app.MapDelete("/api/animals/{id}", (string id, IAnimalService service) =>
{
    return service.DeleteAnimal(id)
    ? TypedResults.NoContent()
    : Results.Problem(statusCode: 404);

}).AddEndpointFilter(ValidationHelper.ValidateId);

app.Run();