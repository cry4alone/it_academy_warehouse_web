namespace Storage.BLL.Common;

/// <summary>
/// Универсальный контейнер для результатов постраничного запроса.
/// Содержит элементы текущей страницы и метаданные пагинации.
/// </summary>
/// <typeparam name="T">Тип элементов в ответе.</typeparam>
public class PagedResponse<T>
{
    /// <summary>
    /// Элементы текущей страницы. По умолчанию — пустой список.
    /// </summary>
    public List<T> Items { get; set; } = [];

    /// <summary>
    /// Номер текущей страницы (1‑индексация).
    /// </summary>
    public int Page { get; set; }

    /// <summary>
    /// Размер страницы (количество элементов на странице).
    /// Должен быть положительным; при значении 0 вычисление <see cref="TotalPages"/> вернёт 0.
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// Общее количество элементов, доступных для пагинации.
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary>
    /// Общее количество страниц, рассчитанное на основе <see cref="TotalCount"/> и <see cref="PageSize"/>.
    /// Возвращает 0, если <see cref="PageSize"/> меньше или равно 0, чтобы избежать деления на ноль.
    /// </summary>
    public int TotalPages => PageSize > 0 ? (int)Math.Ceiling((double)TotalCount / PageSize) : 0;
}