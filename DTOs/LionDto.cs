namespace RestApiAnimals.DTOs
{
    public class LionDto : AnimalDto
    {
        public bool HasMane { get; set; }

        public LionDto() : base("Lion")
        {
            HasMane = true;
        }
    }
}
