using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai01.Models
{
    public class OrderFilter
    {
        // StartDate, EndDate, và Status.
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Status { get; set; }
    }
}