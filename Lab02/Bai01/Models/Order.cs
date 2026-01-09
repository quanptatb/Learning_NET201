using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai01.Models
{
    public class Order
    {
        // OrderId, CustomerName, OrderDate, và Status.
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
    }
}