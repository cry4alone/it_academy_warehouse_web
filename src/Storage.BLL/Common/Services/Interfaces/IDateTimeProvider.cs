namespace Storage.BLL.Common.Services.Interfaces;

/// <summary>
/// Предоставляет UTC-ориентированные значения даты и времени для использования в приложении.
/// Интерфейс позволяет абстрагировать источник текущего времени.
/// </summary>
public interface IDateTimeProvider
{
    /// <summary>
    /// Текущее время в формате UTC.
    /// </summary>
    public DateTime UtcNow { get; }

    /// <summary>
    /// Возвращает дату и время в UTC, сдвинутые на указанное количество месяцев относительно <see cref="UtcNow"/>.
    /// </summary>
    /// <param name="months">Количество месяцев, на которое нужно сдвинуть дату. Может быть отрицательным для сдвига назад.</param>
    /// <returns>Объект <see cref="DateTime"/>, представляющий <see cref="UtcNow"/> плюс указанное количество месяцев.</returns>
    public DateTime UtcMonthFromNow(int months);

    /// <summary>
    /// Возвращает дату и время в UTC, сдвинутые на указанное количество минут относительно <see cref="UtcNow"/>.
    /// </summary>
    /// <param name="minutes">Количество минут, на которое нужно сдвинуть дату. Может быть отрицательным для сдвига назад.</param>
    /// <returns>Объект <see cref="DateTime"/>, представляющий <see cref="UtcNow"/> плюс указанное количество минут.</returns>
    public DateTime UtcMinutesFromNow(int minutes);
}