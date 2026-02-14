using System.ComponentModel.DataAnnotations;

namespace Mission06_LastName.Models
{
    public class Movie
    {
        public int MovieId { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Year is required.")]
        [Range(1888, 2100, ErrorMessage = "Year must be between 1888 and 2100.")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Director is required.")]
        public string Director { get; set; } = string.Empty;

        [Required(ErrorMessage = "Rating is required.")]
        public Rating Rating { get; set; }

        // Edited is required as a yes/no choice on the form
        [Required]
        public bool Edited { get; set; }

        // Not required
        public string? LentTo { get; set; }

        // Not required, but limited to 25 chars
        [StringLength(25, ErrorMessage = "Notes must be 25 characters or less.")]
        public string? Notes { get; set; }

        // Required relationship (normalization)
        [Required]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}