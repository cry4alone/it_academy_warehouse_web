using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

/// <summary>
/// Связь между пользователем и ролью (промежуточная таблица WAREHOUSE.USER_ROLE).
/// Представляет принадлежность пользователя к конкретной роли.
/// </summary>
public partial class UserRole
{
    /// <summary>
    /// Идентификатор пользователя (FK на SYSTEM_USER).
    /// </summary>
    public int UserId { get; set; }

    /// <summary>
    /// Идентификатор роли (FK на ROLE).
    /// </summary>
    public int RoleId { get; set; }

    /// <summary>
    /// Навигационное свойство на роль.
    /// </summary>
    public virtual Role Role { get; set; } = null!;

    /// <summary>
    /// Навигационное свойство на пользователя.
    /// </summary>
    public virtual SystemUser User { get; set; } = null!;
}
