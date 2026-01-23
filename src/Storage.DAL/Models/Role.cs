using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

/// <summary>
/// Роль — разбивает пользователей по задачам/привилегиям в системе (таблица WAREHOUSE.ROLE).
/// </summary>
public partial class Role
{
    /// <summary>
    /// Идентификатор роли (PK).
    /// </summary>
    public int RoleId { get; set; }

    /// <summary>
    /// Название роли (например, "Admin", "WarehouseWorker").
    /// </summary>
    public string Name { get; set; } = null!;
}
