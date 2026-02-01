using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bai03.Models
{
    [Table("students")] // Tên bảng
    public class Student
    {
        [Key]
        [Column("student_id")] // Tên cột trong DB
        public int StudentId { get; set; }

        [Column("first_name", TypeName = "VARCHAR(50)")]
        public string FirstName { get; set; }

        [Column("last_name", TypeName = "VARCHAR(50)")]
        public string LastName { get; set; }

        // Navigation Property: Một sinh viên có nhiều đăng ký
        public virtual ICollection<CourseSubscription> CourseSubscriptions { get; set; }
    }
}