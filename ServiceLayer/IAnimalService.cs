using RestApiAnimals.Domain;
using System.Collections;
using RestApiAnimals.DTOs;

namespace RestApiAnimals.ServiceLayer
{
    public interface IAnimalService
    {
        Task<Animal?> GetAnimalByIdAsync(string id);
        Task<ICollection> GetAllAnimalsAsync();
        Task<bool> AddAnimalAsync(AnimalDto animal);
        Task<bool> FeedAnimalAsync(string id, int feedAmount);
        Task<bool> DeleteAnimalAsync(string id);
    }
}
