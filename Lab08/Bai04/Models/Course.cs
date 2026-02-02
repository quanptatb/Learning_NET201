using System.ComponentModel.DataAnnotations;

namespace Bai04.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string Title { get; set; }

        // Quan hệ 1-nhiều với Enrollment (virtual để Lazy Loading)
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}