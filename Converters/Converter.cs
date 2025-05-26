using Microsoft.Identity.Client;
using RestApiAnimals.DataAccess.Entities;
using RestApiAnimals.Domain;
using RestApiAnimals.DTOs;

namespace RestApiAnimals.Converters
{
    public static class Converter
    {
        public static AnimalEntity? MapDtoToEntity(AnimalDto animalDto)
        {
            return animalDto switch
            {
                LionDto lionDto => new LionEntity
                {
                    Name = lionDto.Name!,
                    Species = lionDto.Species,
                    HaseMane = lionDto.HasMane
                },

                ElephantDto elephantDto => new ElephantEntity
                {
                    Name = elephantDto.Name!,
                    Species = elephantDto.Species,
                    TrunkLength = elephantDto.TrunkLength
                },

                PenguinDto penguinDto => new PenguinEntity
                {
                    Name = penguinDto.Name!,
                    Species = penguinDto.Species,
                    IceSlidingSkill = penguinDto.IceSlidingSkill
                },

                _ => null
            };
        }

        public static AnimalDto? MapEntityToDto(AnimalEntity animalEntity)
        {
            return animalEntity switch
            {
                LionEntity lion => new LionDto
                {
                    Species = lion.Species,
                    Name = lion.Name,
                    Energy = lion.Energy,
                    HasMane = lion.HaseMane
                },

                ElephantEntity elephant => new ElephantDto
                {
                    Species = elephant.Species,
                    Name = elephant.Name,
                    Energy = elephant.Energy,
                    TrunkLength = elephant.TrunkLength
                },

                PenguinEntity penguin => new PenguinDto
                {
                    Species = penguin.Species,
                    Name = penguin.Name,
                    Energy = penguin.Energy,
                    IceSlidingSkill = penguin.IceSlidingSkill
                },

                _ => null
            };
        }

        public static Animal? MapEntityToDomain(AnimalEntity animalEntity)
        {
            return animalEntity switch
            {
                LionEntity lion => new Lion
                {
                    Name = lion.Name,
                    Species = lion.Species,
                    Energy = lion.Energy,
                    HasMane = lion.HaseMane
                },

                ElephantEntity elephant => new Elephant
                {
                    Name = elephant.Name,
                    Species = elephant.Species,
                    Energy = elephant.Energy,
                    TrunkLength = elephant.TrunkLength
                },

                PenguinEntity penguin => new Penguin
                {
                    Name = penguin.Name,
                    Species = penguin.Species,
                    Energy = penguin.Energy,
                    IceSlidingSkill = penguin.IceSlidingSkill
                },

                _ => null
            };
        }

        public static AnimalEntity? MapDomainToEntity(Animal animalDomain)
        {
            return animalDomain switch
            {
                Lion lion => new LionEntity
                {
                    Name = lion.Name,
                    Species = lion.Species,
                    Energy = lion.Energy,
                    HaseMane = lion.HasMane
                },

                Elephant elephant => new ElephantEntity
                {
                    Name = elephant.Name,
                    Species = elephant.Species,
                    Energy = elephant.Energy,
                    TrunkLength = elephant.TrunkLength
                },

                Penguin penguin => new PenguinEntity
                {
                    Name = penguin.Name,
                    Species = penguin.Species,
                    Energy = penguin.Energy,
                    IceSlidingSkill = penguin.IceSlidingSkill
                },

                _ => null
            };
        }
    }
}
