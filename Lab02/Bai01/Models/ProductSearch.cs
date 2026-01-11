using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai01.Models
{
    public class ProductSearch
    {
        // Name, MinPrice, và MaxPrice
        public string Name { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}