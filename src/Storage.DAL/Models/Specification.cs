using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

/// <summary>
/// Спецификация (стандарт) — определяет набор правил/требований к производимой продукции.
/// Представляет запись из таблицы WAREHOUSE.SPECIFICATION.
/// </summary>
public partial class Specification
{
    /// <summary>
    /// Идентификатор спецификации (PK).
    /// </summary>
    public int SpecificationId { get; set; }

    /// <summary>
    /// Название спецификации/стандарта.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Схемы контроля, использующие данную спецификацию.
    /// </summary>
    public virtual ICollection<ControlScheme> ControlSchemes { get; set; } = new List<ControlScheme>();

    /// <summary>
    /// Выплавки (melts), у которых указана эта спецификация.
    /// </summary>
    public virtual ICollection<Melt> Melts { get; set; } = new List<Melt>();
}
