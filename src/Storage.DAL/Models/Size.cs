using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

public partial class Size
{
    public int SizeId { get; set; }

    public decimal? Length { get; set; }

    public decimal? Width { get; set; }

    public decimal Height { get; set; }

    public decimal? Radius { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
