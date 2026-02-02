using System.ComponentModel.DataAnnotations;

namespace Bai04.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string Name { get; set; }

        // Quan hệ 1-nhiều với Enrollment (virtual để Lazy Loading)
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}