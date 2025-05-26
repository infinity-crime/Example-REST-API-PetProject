using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RestApiAnimals.Domain
{
    [JsonPolymorphic(TypeDiscriminatorPropertyName = "Species")]
    [JsonDerivedType(typeof(Lion), "Lion")]
    [JsonDerivedType(typeof(Elephant), "Elephant")]
    [JsonDerivedType(typeof(Penguin), "Penguin")]
    public class Animal : IAnimal
    {
        public string? Name { get; set; }

        [JsonIgnore]
        public string? Species { get; set; }

        public int Energy { get; set; }

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
