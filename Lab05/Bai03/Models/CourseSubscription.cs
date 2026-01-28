using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bai03.Models
{
    [Table("course_subscriptions")]
    public class CourseSubscription
    {
        // Khóa ngoại trỏ về Student
        [Column("student_id")]
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

        // Khóa ngoại trỏ về Course
        [Column("course_id")]
        public int CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}