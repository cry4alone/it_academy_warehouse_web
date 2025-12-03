using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

public partial class DocumentReversal
{
    public int DocumentReversalId { get; set; }

    public int ShipmentInvoiceId { get; set; }

    public string Reason { get; set; } = null!;

    public int CreatedByUserId { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual SystemUser CreatedByUser { get; set; } = null!;

    public virtual ShipmentInvoice ShipmentInvoice { get; set; } = null!;
}
