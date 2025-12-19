namespace Storage.BLL.Common;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
    public DateTime UtcMonthFromNow(int months)
    {
        return DateTime.UtcNow.AddMonths(months);
    }
}