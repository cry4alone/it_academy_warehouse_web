using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

public partial class Transport
{
    public int TransportId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; } = new List<PurchaseOrder>();
}
