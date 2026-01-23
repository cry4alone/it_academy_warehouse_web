using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

public partial class Label
{
    public int LabelId { get; set; }

    public int CertificateId { get; set; }

    public int MeltId { get; set; }

    public string SizeMm { get; set; } = null!;

    public int NetKg { get; set; }

    public int GrossKg { get; set; }

    public string SizeInch { get; set; } = null!;

    public decimal NetB { get; set; }

    public decimal GrossB { get; set; }

    public virtual Certificate Certificate { get; set; } = null!;

    public virtual Melt Melt { get; set; } = null!;
}
