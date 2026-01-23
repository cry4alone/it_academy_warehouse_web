using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

public partial class Weigher
{
    public int WeigherId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ManualWeighingInvoice> ManualWeighingInvoices { get; set; } = new List<ManualWeighingInvoice>();
}
