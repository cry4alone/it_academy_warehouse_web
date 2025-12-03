using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

public partial class MeltStatus
{
    public int MeltStatusId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Melt> Melts { get; set; } = new List<Melt>();
}
