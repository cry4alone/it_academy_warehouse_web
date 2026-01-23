using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

/// <summary>
/// Марка — сорт алюминия (таблица WAREHOUSE.BRAND).
/// Определяет название марки и связи на схемы контроля и плавки.
/// </summary>
public partial class Brand
{
    /// <summary>
    /// Идентификатор марки (PK).
    /// </summary>
    public int BrandId { get; set; }

    /// <summary>
    /// Название марки.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Схемы контроля, в которых используется данная марка.
    /// </summary>
    public virtual ICollection<ControlScheme> ControlSchemes { get; set; } = new List<ControlScheme>();

    /// <summary>
    /// Выплавки (melts), произведённые из этой марки.
    /// </summary>
    public virtual ICollection<Melt> Melts { get; set; } = new List<Melt>();
}
