using RestApiAnimals.Models;
using System.Collections;
using System.Collections.Concurrent;

namespace RestApiAnimals.ServiceLayer
{
    public class AnimalService : IAnimalService
    {
        private static ConcurrentDictionary<string, IAnimal> _animals = new();
        public bool AddAnimal(string id, IAnimal animal)
        {
            return _animals.TryAdd(id, animal);
        }

        public bool DeleteAnimal(string id)
        {
            return _animals.TryRemove(id, out _);
        }

        public bool FeedAnimal(string id, int feedAmount)
        {
            _animals.TryGetValue(id, out IAnimal? animal);
            if (animal is null)
                return false;

            animal.TakeFood(feedAmount);
            return true;
        }

        public IDictionary GetAllAnimals()
        {
            return _animals;
        }

        public IAnimal? GetAnimalById(string id)
        {
            _animals.TryGetValue(id, out IAnimal? animal);
            return animal;
        }
    }
}
