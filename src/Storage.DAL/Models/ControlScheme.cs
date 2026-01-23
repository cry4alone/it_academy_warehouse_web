using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

/// <summary>
/// Схема контроля для продукции — объединяет спецификацию, продукт и марку.
/// Представляет запись из таблицы WAREHOUSE.CONTROL_SCHEME.
/// </summary>
public partial class ControlScheme
{
    /// <summary>
    /// Идентификатор схемы контроля (PK).
    /// </summary>
    public int ControlSchemeId { get; set; }

    /// <summary>
    /// Идентификатор спецификации (FK на Specification).
    /// </summary>
    public int SpecificationId { get; set; }

    /// <summary>
    /// Идентификатор продукта (FK на Product).
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Идентификатор марки (FK на Brand).
    /// </summary>
    public int BrandId { get; set; }

    /// <summary>
    /// Марка алюминия, связанная с данной схемой контроля.
    /// </summary>
    public virtual Brand Brand { get; set; } = null!;

    /// <summary>
    /// Сертификаты, связанные с данной схемой контроля.
    /// </summary>
    public virtual ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();

    /// <summary>
    /// Продукт, для которого действует эта схема контроля.
    /// </summary>
    public virtual Product Product { get; set; } = null!;

    /// <summary>
    /// Спецификация, используемая в схеме контроля.
    /// </summary>
    public virtual Specification Specification { get; set; } = null!;
}
