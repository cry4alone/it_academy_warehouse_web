using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

public partial class Permission
{
    public int PermissionId { get; set; }

    public string Name { get; set; } = null!;
}
