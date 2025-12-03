using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

public partial class ControlScheme
{
    public int ControlSchemeId { get; set; }

    public int SpecificationId { get; set; }

    public int ProductId { get; set; }

    public int BrandId { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();

    public virtual Product Product { get; set; } = null!;

    public virtual Specification Specification { get; set; } = null!;
}
