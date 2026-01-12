using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

/// <summary>
/// Разрешение — действие, которое может выполнять роль (например, Create, Delete, Sign).
/// Представляет запись из таблицы WAREHOUSE.PERMISSION.
/// </summary>
public partial class Permission
{
    /// <summary>
    /// Идентификатор разрешения (PK).
    /// </summary>
    public int PermissionId { get; set; }

    /// <summary>
    /// Название разрешения.
    /// </summary>
    public string Name { get; set; } = null!;
}
