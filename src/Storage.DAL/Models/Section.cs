using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

public partial class Section
{
    public int SectionId { get; set; }

    public string Name { get; set; } = null!;

    public int WarehouseId { get; set; }

    public virtual Warehouse Warehouse { get; set; } = null!;
}
