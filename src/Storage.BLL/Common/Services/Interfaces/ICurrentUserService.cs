using Storage.DAL.Models;

namespace Storage.BLL.Common;

public interface ICurrentUserService
{
    public int UserId { get; }
    public Task<SystemUser> GetCurrentUserAsync();
}