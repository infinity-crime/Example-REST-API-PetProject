namespace RestApiAnimals.Models
{
    public class Lion : Animal
    {
        public bool HasMane { get; set; }
        public Lion() : base("lion")
        {
            HasMane = true;
        }

        public override void PlaySound()
        {
            Console.WriteLine("Rrroar!");
        }
    }
}
