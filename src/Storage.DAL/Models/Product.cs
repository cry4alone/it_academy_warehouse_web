using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

/// <summary>
/// Продукт — тип продукции, производимый компанией. Содержит название и ссылку на размеры.
/// Представляет запись из таблицы WAREHOUSE.PRODUCT.
/// </summary>
public partial class Product
{
    /// <summary>
    /// Идентификатор продукта (PK).
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Название продукта.
    /// </summary>
    public string Name { get; set; } = null!;

    /// <summary>
    /// Идентификатор набора размеров для данного продукта (FK на Size).
    /// </summary>
    public int SizeId { get; set; }

    /// <summary>
    /// Схемы контроля, связанные с данным продуктом.
    /// </summary>
    public virtual ICollection<ControlScheme> ControlSchemes { get; set; } = new List<ControlScheme>();

    /// <summary>
    /// Выплавки (плавки), произведённые для данного продукта.
    /// </summary>
    public virtual ICollection<Melt> Melts { get; set; } = new List<Melt>();

    /// <summary>
    /// Навигационное свойство на набор размеров продукта.
    /// </summary>
    public virtual Size Size { get; set; } = null!;
}
