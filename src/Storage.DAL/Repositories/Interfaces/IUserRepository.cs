using Storage.DAL.Models;
using System.Threading;

namespace Storage.DAL.Repositories.Interfaces;

public interface IUserRepository
{
    public Task<SystemUser?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default);
    public Task<SystemUser?> GetByIdAsync(int userId, CancellationToken cancellationToken = default);
    public Task<SystemUser?> AddUserAsync(SystemUser newUser, CancellationToken cancellationToken = default);
    public Task<List<string>> GetUserRolesAsync(int userId, CancellationToken cancellationToken = default);
}