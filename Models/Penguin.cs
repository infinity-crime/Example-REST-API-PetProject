namespace RestApiAnimals.Models
{
    public class Penguin : Animal
    {
        public int IceSlidingSkill { get; set; }
        public Penguin() : base("penguin")
        {
            IceSlidingSkill = new Random().Next(1, 10);
        }

        public override void PlaySound()
        {
            Console.WriteLine("Honk! Honk! Honk!");
        }
    }
}
