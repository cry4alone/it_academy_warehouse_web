using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

public partial class Certificate
{
    public int CertificateId { get; set; }

    public int PurchaseOrderId { get; set; }

    public int WarehouseId { get; set; }

    public int? ControlSchemeId { get; set; }

    public int? UserId { get; set; }

    public int CreatedByUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedByUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedByUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual ICollection<AcceptanceInvoice> AcceptanceInvoices { get; set; } = new List<AcceptanceInvoice>();

    public virtual ControlScheme? ControlScheme { get; set; }

    public virtual SystemUser CreatedByUser { get; set; } = null!;

    public virtual SystemUser? DeletedByUser { get; set; }

    public virtual ICollection<Label> Labels { get; set; } = new List<Label>();

    public virtual ICollection<Melt> Melts { get; set; } = new List<Melt>();

    public virtual PurchaseOrder PurchaseOrder { get; set; } = null!;

    public virtual ICollection<RedistributionOfMelting> RedistributionOfMeltingCertificateFroms { get; set; } = new List<RedistributionOfMelting>();

    public virtual ICollection<RedistributionOfMelting> RedistributionOfMeltingCertificateTos { get; set; } = new List<RedistributionOfMelting>();

    public virtual ICollection<ShipmentInvoice> ShipmentInvoices { get; set; } = new List<ShipmentInvoice>();

    public virtual SystemUser? UpdatedByUser { get; set; }

    public virtual SystemUser? User { get; set; }

    public virtual Warehouse Warehouse { get; set; } = null!;
}
