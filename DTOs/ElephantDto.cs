namespace RestApiAnimals.DTOs
{
    public class ElephantDto : AnimalDto
    {
        public double TrunkLength { get; set; }

        public ElephantDto() : base("Elephant")
        {
            TrunkLength = 1.5 + new Random().NextDouble() * 2;
        }
    }
}
