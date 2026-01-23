using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

public partial class ReturnType
{
    public int ReturnTypeId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<ReturnInvoice> ReturnInvoices { get; set; } = new List<ReturnInvoice>();
}
