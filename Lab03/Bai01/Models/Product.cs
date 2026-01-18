using System;
using System.Collections.Generic;

namespace Bai01.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Color { get; set; }

    public decimal? UnitPrice { get; set; }

    public bool? AvailableQuantity { get; set; }

    public DateTime? CratedDate { get; set; }
}
