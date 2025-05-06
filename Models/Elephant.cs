namespace RestApiAnimals.Models
{
    public class Elephant : Animal
    {
        public double TrunkLength { get; set; }
        public Elephant() : base("elephant")
        {
            TrunkLength = 1.5 + new Random().NextDouble() * 2;
        }
        public override void PlaySound()
        {
            Console.WriteLine("Trumpet!");
        }
    }
}
