using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bai03.Models
{
    [Table("courses")]
    public class Course
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("name", TypeName = "VARCHAR(100)")]
        public string Name { get; set; }

        [Column("start_date", TypeName = "DATE")]
        public DateTime StartDate { get; set; }

        // Navigation Property: Một khóa học có nhiều đăng ký
        public virtual ICollection<CourseSubscription> CourseSubscriptions { get; set; }
    }
}