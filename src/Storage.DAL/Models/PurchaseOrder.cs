using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

public partial class PurchaseOrder
{
    public int PurchaseOrderId { get; set; }

    public int CustomerId { get; set; }

    public string Description { get; set; } = null!;

    public int TransportId { get; set; }

    public int CreatedByUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedByUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedByUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();

    public virtual SystemUser CreatedByUser { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual SystemUser? DeletedByUser { get; set; }

    public virtual ICollection<ShipmentInvoice> ShipmentInvoices { get; set; } = new List<ShipmentInvoice>();

    public virtual Transport Transport { get; set; } = null!;

    public virtual SystemUser? UpdatedByUser { get; set; }
}
