using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Mission06_Lindsey.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int MovieID { get; set; }

        [ForeignKey("CategoryID")] // Specify the foreign key relationship
 
        public int CategoryID { get; set; }
        public Category? Category { get; set; }
        [Required(ErrorMessage = "You must enter a title")]
        public string Title { get; set; }
        [Required]
        [Range(1888, int.MaxValue, ErrorMessage = "Year must be at least 1888, when the first movie was made.")]
        public int Year { get; set; }
        public string? Director { get; set; }
        public string? Rating { get; set; }
        [Required(ErrorMessage = "You must select whether or not it was edited")]
        public bool? Edited { get; set; }
        public string? LentTo { get; set; }
        [Required(ErrorMessage = "You must select whether or not it was Copied to Plex")]
        public bool? CopiedToPlex { get; set; }
        public string? Notes { get; set; }

        // Navigation property
    }
}
