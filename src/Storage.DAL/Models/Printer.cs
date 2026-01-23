using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

public partial class Printer
{
    public int PrinterId { get; set; }

    public string Name { get; set; } = null!;
}
