using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

public partial class RedistributionOfMelting
{
    public int RedistributionOfMeltingId { get; set; }

    public int CertificateFromId { get; set; }

    public int MeltId { get; set; }

    public int CertificateToId { get; set; }

    public int CreatedByUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual Certificate CertificateFrom { get; set; } = null!;

    public virtual Certificate CertificateTo { get; set; } = null!;

    public virtual SystemUser CreatedByUser { get; set; } = null!;

    public virtual Melt Melt { get; set; } = null!;
}
