using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bai01.Models
{
    [Table("student_details")]
    public class StudentDetailB
    {
        [Key, ForeignKey("Student")] // Khóa chính đồng thời là khóa ngoại (1-1)
        [Column("student_id", TypeName = "INT")]
        public int StudentId { get; set; }

        [Column("email", TypeName = "VARCHAR(100)")]
        public string Email { get; set; }

        [Column("date_birth", TypeName = "DATE")]
        public DateTime DateBirth { get; set; }

        public virtual StudentB Student { get; set; }
    }
}