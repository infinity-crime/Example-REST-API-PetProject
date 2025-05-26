using System.ComponentModel.DataAnnotations;

namespace RestApiAnimals.DataAccess.Entities
{
    public abstract class AnimalEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Name { get; set; }

        [Required]
        public required string Species { get; set; }

        [Range(0, 100)]
        public int Energy { get; set; } = 100;
    }
}
