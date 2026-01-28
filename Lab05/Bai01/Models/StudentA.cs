using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai01.Models
{
    public class StudentA
    {
        public int Id { get; set; } // EF Convention tự hiểu là PK
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        // Navigation Property
        public virtual StudentDetailA StudentDetail { get; set; }
    }
}