using System.ComponentModel.DataAnnotations;

namespace Bai03.Models
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        [Required]
        [StringLength(100)]
        public string AuthorName { get; set; }

        // Navigation property
        public ICollection<Book>? Books { get; set; }
    }
}