using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai01.Models
{
    public class StudentDetailC
    {
        public int StudentId { get; set; }
        public string Email { get; set; }
        public DateTime DateBirth { get; set; }
        public virtual StudentC Student { get; set; }
    }
}