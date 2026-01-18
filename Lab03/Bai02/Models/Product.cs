using System;
using System.Collections.Generic;

namespace Bai02.Models;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public decimal Price { get; set; }

    public decimal? SalePrice { get; set; }

    public string? ImageName { get; set; }

    public string? Description { get; set; }

    public int? CategoryId { get; set; }

    public virtual Category? Category { get; set; }
}
