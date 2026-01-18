using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bai03.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [StringLength(250)]
        public string? Name { get; set; } // varchar(250), Allow Nulls

        [Column(TypeName = "money")]
        public decimal? Price { get; set; } // money, Allow Nulls

        public int? Quantity { get; set; } // int, Allow Nulls

        public bool? Status { get; set; } // bit, Allow Nulls
    }
}