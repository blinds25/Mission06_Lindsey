using System.ComponentModel.DataAnnotations;
namespace Mission06_Lindsey.Models
{
    public class Category
    {
        [Key]
        [Required]
        public int CategoryID { get; set; }

        public string? CategoryName { get; set; } 

        public ICollection<Movie> Movies { get; set; }
    }
}
