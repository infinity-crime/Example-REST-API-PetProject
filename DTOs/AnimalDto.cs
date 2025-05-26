using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RestApiAnimals.DTOs
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "Species")]
    [JsonDerivedType(typeof(LionDto), "Lion")]
    [JsonDerivedType(typeof(ElephantDto), "Elephant")]
    [JsonDerivedType(typeof(PenguinDto), "Penguin")]
    public class AnimalDto
    {
        [Required]
        [MaxLength(50)]
        public string? Name { get; set; }

        [JsonIgnore]
        public string Species { get; set; }

        [JsonIgnore]
        public int Energy { get; set; }

        public AnimalDto(string species) => Species = species;
    }
}
