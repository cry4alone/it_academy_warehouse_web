using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

public partial class ManualWeighingInvoiceMelt
{
    public int ManualWeighingInvoiceMeltId { get; set; }

    public int ManualWeighingInvoiceId { get; set; }

    public int MeltId { get; set; }

    public virtual ManualWeighingInvoice ManualWeighingInvoice { get; set; } = null!;

    public virtual Melt Melt { get; set; } = null!;
}
