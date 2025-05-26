using Microsoft.AspNetCore.Http.Json;
using RestApiAnimals.Domain;
using RestApiAnimals.DTOs;
using RestApiAnimals.ServiceLayer;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization.Metadata;

namespace RestApiAnimals.Extensions
{
    public static class AddServicesExtension
    {
        public static IServiceCollection AddMainServices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            // Configuring SwaggerGen to ensure it outputs the correct expected JSON to Swagger,
            // as it does not initially see the mandatory SpeciesType field
            services.AddSwaggerGen(o =>
            {
                o.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()
                {
                    Title = "Zoo management",
                    Description = "This API is created to manage animal data in the zoo",
                    Version = "2.0"
                });

                o.UseOneOfForPolymorphism();

                o.SelectDiscriminatorNameUsing(type => type.Name switch
                {
                    nameof(AnimalDto) => "Species",
                    _ => null
                });
            });

            services.AddScoped<IAnimalService, AnimalService>();

            return services;
        }
    }
}
