namespace RestApiAnimals.Models
{
    public interface IAnimal
    {
        string? Species { get; set; }
        string? Name { get; set; }
        int Energy { get; }
        void PlaySound();
        void TakeFood(int amount);
    }
}
