using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

public partial class ManualWeighingInvoice
{
    public int ManualWeighingInvoiceId { get; set; }

    public int WeigherId { get; set; }

    public int CountPosition { get; set; }

    public int AuthorId { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual SystemUser Author { get; set; } = null!;

    public virtual ICollection<ManualWeighingInvoiceMelt> ManualWeighingInvoiceMelts { get; set; } = new List<ManualWeighingInvoiceMelt>();

    public virtual Weigher Weigher { get; set; } = null!;
}
