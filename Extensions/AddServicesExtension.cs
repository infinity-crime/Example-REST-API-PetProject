using RestApiAnimals.Models;
using RestApiAnimals.ServiceLayer;
using System.Runtime.CompilerServices;

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
                o.UseOneOfForPolymorphism();
                o.SelectDiscriminatorNameUsing(type => type.Name switch
                {
                    nameof(Animal) => "SpeciesType",
                    _ => null
                });
            });

            // The service is registered as Scoped due to project requirements
            services.AddScoped<IAnimalService, AnimalService>();

            return services;
        }
    }
}
