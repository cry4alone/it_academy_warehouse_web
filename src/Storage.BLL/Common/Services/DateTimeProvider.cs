using Storage.BLL.Common.Services.Interfaces;

namespace Storage.BLL.Common.Services;

/// <inheritdoc cref="IDateTimeProvider" />
public class DateTimeProvider : IDateTimeProvider
{
    /// <inheritdoc />
    public DateTime UtcNow => DateTime.UtcNow;

    /// <inheritdoc />
    public DateTime UtcMonthFromNow(int months)
    {
        return DateTime.UtcNow.AddMonths(months);
    }
    
    public DateTime UtcMinutesFromNow(int minutes)
    {
        return DateTime.UtcNow.AddMinutes(minutes);
    }
}