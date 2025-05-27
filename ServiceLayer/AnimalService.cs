using RestApiAnimals.Domain;
using RestApiAnimals.DTOs;
using System.Collections;
using System.Collections.Concurrent;
using RestApiAnimals.Converters;
using System.Runtime.CompilerServices;
using RestApiAnimals.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace RestApiAnimals.ServiceLayer
{
    public class AnimalService : IAnimalService
    {
        private readonly AppDbContext _appDbContext;

        public AnimalService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<bool> AddAnimalAsync(AnimalDto animal)
        {
            var animalEntity = Converter.MapDtoToEntity(animal);
            if (animalEntity != null)
            {
                await _appDbContext.AddAsync(animalEntity);
                await _appDbContext.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> DeleteAnimalAsync(string id)
        {
            if(int.TryParse(id, out int animalId))
            {
                var animal = await _appDbContext.Animals
                    .FirstOrDefaultAsync(a => a.Id == animalId);
                if (animal != null)
                {
                    _appDbContext.Animals.Remove(animal);
                    await _appDbContext.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            
            return false;
        }

        public async Task<bool> FeedAnimalAsync(string id, int feedAmount)
        {
            if(int.TryParse(id, out int animalId))
            {
                var animal = await _appDbContext.Animals
                    .FirstOrDefaultAsync(a => a.Id == animalId);
                if(animal != null)
                {
                    var animalDomain = Converter.MapEntityToDomain(animal);
                    animalDomain!.TakeFood(feedAmount);

                    animal.Energy = animalDomain.Energy;
                    await _appDbContext.SaveChangesAsync();

                    return true;
                }

                return false;
            }

            return false;
        }

        public async Task<ICollection> GetAllAnimalsAsync()
        {
            var animals = await _appDbContext.Animals
                .ToListAsync();

            return animals
                .Select(Converter.MapEntityToDomain)
                .ToList();
        }

        public async Task<Animal?> GetAnimalByIdAsync(string id)
        {
            if(int.TryParse(id, out int animalId))
            {
                var animal = await _appDbContext.Animals
                    .FirstOrDefaultAsync(a => a.Id == animalId);
                if (animal != null)
                {
                    return Converter.MapEntityToDomain(animal);
                }

                return null;
            }

            return null;
        }
    }
}
