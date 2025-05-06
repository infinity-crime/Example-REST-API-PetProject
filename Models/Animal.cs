using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RestApiAnimals.Models
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "SpeciesType")]
    [JsonDerivedType(typeof(Lion), "lion")]
    [JsonDerivedType(typeof(Penguin), "penguin")]
    [JsonDerivedType(typeof(Elephant), "elephant")]
    public class Animal : IAnimal
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "Name")]
        public string? Name { get; set; }

        [JsonIgnore]
        public string? Species { get; set; }

        public int Energy { get; private set; }

        public Animal(string species)
        {
            Species = species;
            Energy = 100;
        }

        public virtual void PlaySound()
        {
            Console.WriteLine("some sound...");
        }

        public void TakeFood(int amount)
        {
            Energy = Math.Min(Energy, Energy + amount);
            Console.WriteLine($"{Name} ({Species}): Thank you for {amount} units of food!");
        }
    }
}
