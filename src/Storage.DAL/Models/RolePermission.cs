using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

/// <summary>
/// Связь между ролью и разрешением (промежуточная таблица WAREHOUSE.ROLE_PERMISSION).
/// Отображает, какие разрешения принадлежат каждой роли.
/// </summary>
public partial class RolePermission
{
    /// <summary>
    /// Идентификатор связи (FK).
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// Идентификатор роли (FK на Role).
    /// </summary>
    public int RoleId { get; set; }

    /// <summary>
    /// Идентификатор разрешения (FK на Permission).
    /// </summary>
    public int PermissionId { get; set; }

    /// <summary>
    /// Навигационное свойство на разрешение.
    /// </summary>
    public virtual Permission Permission { get; set; } = null!;

    /// <summary>
    /// Навигационное свойство на роль.
    /// </summary>
    public virtual Role Role { get; set; } = null!;
}
