using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

public partial class Brand
{
    public int BrandId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ControlScheme> ControlSchemes { get; set; } = new List<ControlScheme>();

    public virtual ICollection<Melt> Melts { get; set; } = new List<Melt>();
}
