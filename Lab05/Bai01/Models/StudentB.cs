using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bai01.Models
{
    [Table("students")] // Tên bảng
    public class StudentB
    {
        [Key]
        [Column("student_id", TypeName = "INT")] // Tên cột và kiểu
        public int StudentId { get; set; }

        [Column("first_name", TypeName = "VARCHAR(50)")]
        public string FirstName { get; set; }

        [Column("last_name", TypeName = "VARCHAR(50)")]
        public string LastName { get; set; }

        public virtual StudentDetailB StudentDetail { get; set; }
    }
}