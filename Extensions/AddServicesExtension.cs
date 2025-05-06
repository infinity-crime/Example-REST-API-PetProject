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
            services.AddSwaggerGen(o =>
            {
                o.UseOneOfForPolymorphism();
                o.SelectDiscriminatorNameUsing(type => type.Name switch
                {
                    nameof(Animal) => "SpeciesType",
                    _ => null
                });
            });
            services.AddScoped<IAnimalService, AnimalService>();

            return services;
        }
    }
}
