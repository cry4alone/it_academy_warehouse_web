using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

public partial class Invoice
{
    public int InvoiceId { get; set; }

    public int WarehouseId { get; set; }

    public int CreatedByUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int? UpdatedByUserId { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public int? DeletedByUserId { get; set; }

    public DateTime? DeletedDate { get; set; }

    public virtual ICollection<AcceptanceInvoice> AcceptanceInvoices { get; set; } = new List<AcceptanceInvoice>();

    public virtual SystemUser CreatedByUser { get; set; } = null!;

    public virtual SystemUser? DeletedByUser { get; set; }

    public virtual ICollection<ReturnInvoice> ReturnInvoices { get; set; } = new List<ReturnInvoice>();

    public virtual ICollection<ShipmentInvoice> ShipmentInvoices { get; set; } = new List<ShipmentInvoice>();

    public virtual SystemUser? UpdatedByUser { get; set; }

    public virtual Warehouse Warehouse { get; set; } = null!;
}
