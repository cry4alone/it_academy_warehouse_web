namespace Storage.BLL.Common;

public interface IDateTimeProvider
{
    public DateTime UtcNow { get; }
}