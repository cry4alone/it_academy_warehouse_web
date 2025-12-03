using Microsoft.EntityFrameworkCore;
using Storage.DAL.Models;

namespace Storage.DAL.Repositories;

public class UserRepository
{
    public readonly WarehouseContext _context;
    
    public UserRepository(WarehouseContext context)
    {
        _context = context;
    }
    
    public async Task<SystemUser?> GetByUsernameAsync(string username)
    {
        return await _context.SystemUsers
            .FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task<SystemUser?> GetByIdAsync(int userId)
    {
        return await _context.SystemUsers.FirstOrDefaultAsync(u => u.UserId == userId);
    }
    
}