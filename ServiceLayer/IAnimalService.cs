using RestApiAnimals.Models;
using System.Collections;

namespace RestApiAnimals.ServiceLayer
{
    public interface IAnimalService
    {
        IAnimal? GetAnimalById(string id);
        IDictionary GetAllAnimals();
        bool AddAnimal(string id, IAnimal animal);
        bool FeedAnimal(string id, int feedAmount);
        bool DeleteAnimal(string id);
    }
}
