namespace RestApiAnimals.DTOs
{
    public class PenguinDto : AnimalDto
    {
        public int IceSlidingSkill { get; set; }

        public PenguinDto() : base("Penguin")
        {
            IceSlidingSkill = new Random().Next(1, 10);
        }
    }
}
