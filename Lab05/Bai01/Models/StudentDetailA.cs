using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai01.Models
{
    public class StudentDetailA
    {
        public int Id { get; set; } // Dùng Id làm PK
        public string Email { get; set; }
        public DateTime DateBirth { get; set; }

        // Navigation Property & FK (Convention 1-1 shared PK)
        public int StudentId { get; set; } // FK
        public virtual StudentA Student { get; set; }
    }
}