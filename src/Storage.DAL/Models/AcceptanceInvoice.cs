using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

public partial class AcceptanceInvoice
{
    public int AcceptanceInvoiceId { get; set; }

    public int InvoiceId { get; set; }

    public int RecipientWarehouseId { get; set; }

    public int? CertificateId { get; set; }

    public int UserId { get; set; }

    public DateTime? SignedDate { get; set; }

    public virtual Certificate? Certificate { get; set; }

    public virtual Invoice Invoice { get; set; } = null!;

    public virtual Warehouse RecipientWarehouse { get; set; } = null!;

    public virtual SystemUser User { get; set; } = null!;
}
