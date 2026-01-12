using System;
using System.Collections.Generic;

namespace Storage.DAL.Models;

/// <summary>
/// Размеры продукции. Поля могут использоваться по необходимости для различных типов продукции (длина, ширина, высота, радиус).
/// Представляет запись из таблицы WAREHOUSE.SIZE.
/// </summary>
public partial class Size
{
    /// <summary>
    /// Идентификатор размера (PK).
    /// </summary>
    public int SizeId { get; set; }

    /// <summary>
    /// Длина продукции.
    /// </summary>
    public decimal? Length { get; set; }

    /// <summary>
    /// Ширина продукции.
    /// </summary>
    public decimal? Width { get; set; }

    /// <summary>
    /// Высота продукции.
    /// </summary>
    public decimal Height { get; set; }

    /// <summary>
    /// Радиус продукции.
    /// </summary>
    public decimal? Radius { get; set; }

    /// <summary>
    /// Продукты, которые используют этот набор размеров.
    /// </summary>
    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
