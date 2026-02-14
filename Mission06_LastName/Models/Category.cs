using System.ComponentModel.DataAnnotations;

namespace Mission06_LastName.Models
{
    public class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public string Name { get; set; } = string.Empty;

        // Navigation
        public List<Movie> Movies { get; set; } = new();
    }
}