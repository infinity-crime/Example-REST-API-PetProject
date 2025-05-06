using System.ComponentModel.DataAnnotations;

namespace RestApiAnimals.DTOs
{
    public class FeedDto
    {
        [Required]
        [Range(1, 100)]
        [Display(Name = "Feed amount")]
        public int FeedAmount { get; set; }
    }
}
