namespace Storage.BLL.Common;

public interface IDateTimeProvider
{
    public DateTime UtcNow { get; }
    public DateTime UtcMonthFromNow(int months);
}