using Storage.DAL.Models;

namespace Storage.DAL.Repositories.Interfaces;

public interface IUserRepository
{
    public Task<SystemUser?> GetByUsernameAsync(string username);
    public Task<SystemUser?> GetByIdAsync(int userId);
    public Task<SystemUser?> AddUserAsync(SystemUser newUser);
    public Task<List<string>> GetUserRolesAsync(int userId);
}