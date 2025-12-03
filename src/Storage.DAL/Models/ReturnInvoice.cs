using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

public partial class ReturnInvoice
{
    public int ReturnInvoiceId { get; set; }

    public int InvoiceId { get; set; }

    public int RecipientWarehouseId { get; set; }

    public int ReturnTypeId { get; set; }

    public int? ReasonForReturnId { get; set; }

    public string Description { get; set; } = null!;

    public virtual Invoice Invoice { get; set; } = null!;

    public virtual ReasonForReturn? ReasonForReturn { get; set; }

    public virtual Warehouse RecipientWarehouse { get; set; } = null!;

    public virtual ICollection<ReturnInvoiceMelt> ReturnInvoiceMelts { get; set; } = new List<ReturnInvoiceMelt>();

    public virtual ReturnType ReturnType { get; set; } = null!;
}
