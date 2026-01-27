using System.ComponentModel.DataAnnotations;

namespace Lab06.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}