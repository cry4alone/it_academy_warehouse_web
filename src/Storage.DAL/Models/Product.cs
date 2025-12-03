using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = null!;

    public int SizeId { get; set; }

    public virtual ICollection<ControlScheme> ControlSchemes { get; set; } = new List<ControlScheme>();

    public virtual ICollection<Melt> Melts { get; set; } = new List<Melt>();

    public virtual Size Size { get; set; } = null!;
}
