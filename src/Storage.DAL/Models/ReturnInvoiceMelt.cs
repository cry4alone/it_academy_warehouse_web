using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

public partial class ReturnInvoiceMelt
{
    public int ReturnInvoiceMeltId { get; set; }

    public int ReturnInvoiceId { get; set; }

    public int MeltId { get; set; }

    public virtual Melt Melt { get; set; } = null!;

    public virtual ReturnInvoice ReturnInvoice { get; set; } = null!;
}
