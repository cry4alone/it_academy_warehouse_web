using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

public partial class Warehouse
{
    public int WarehouseId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<AcceptanceInvoice> AcceptanceInvoices { get; set; } = new List<AcceptanceInvoice>();

    public virtual ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<ReturnInvoice> ReturnInvoices { get; set; } = new List<ReturnInvoice>();

    public virtual ICollection<Section> Sections { get; set; } = new List<Section>();
}
