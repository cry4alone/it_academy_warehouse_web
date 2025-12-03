using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

public partial class Melt
{
    public int MeltId { get; set; }

    public int ProductId { get; set; }

    public int BrandId { get; set; }

    public int? CertificateId { get; set; }

    public int SpecificationId { get; set; }

    public DateTime ProductionDate { get; set; }

    public int MeltStatusId { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual Certificate? Certificate { get; set; }

    public virtual ICollection<Label> Labels { get; set; } = new List<Label>();

    public virtual ICollection<ManualWeighingInvoiceMelt> ManualWeighingInvoiceMelts { get; set; } = new List<ManualWeighingInvoiceMelt>();

    public virtual MeltStatus MeltStatus { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;

    public virtual ICollection<RedistributionOfMelting> RedistributionOfMeltings { get; set; } = new List<RedistributionOfMelting>();

    public virtual ICollection<ReturnInvoiceMelt> ReturnInvoiceMelts { get; set; } = new List<ReturnInvoiceMelt>();

    public virtual Specification Specification { get; set; } = null!;
}
