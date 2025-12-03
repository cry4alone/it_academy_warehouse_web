using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

public partial class ShipmentInvoice
{
    public int ShipmentInvoiceId { get; set; }

    public int InvoiceId { get; set; }

    public int PurchaseOrderId { get; set; }

    public int TotalWeight { get; set; }

    public int CertificateId { get; set; }

    public virtual Certificate Certificate { get; set; } = null!;

    public virtual ICollection<DocumentReversal> DocumentReversals { get; set; } = new List<DocumentReversal>();

    public virtual Invoice Invoice { get; set; } = null!;

    public virtual PurchaseOrder PurchaseOrder { get; set; } = null!;
}
