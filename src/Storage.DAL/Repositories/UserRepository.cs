using Microsoft.EntityFrameworkCore;
using Storage.DAL.Models;
using Storage.DAL.Repositories.Interfaces;
using System.Threading;

namespace Storage.DAL.Repositories;

public class UserRepository : IUserRepository
{
    private readonly WarehouseContext _context;
    
    public UserRepository(WarehouseContext context)
    {
        _context = context;
    }
    
    public async Task<SystemUser?> GetByUsernameAsync(string username, CancellationToken cancellationToken = default)
    {
        return await _context.SystemUsers
            .FirstOrDefaultAsync(u => u.Username == username, cancellationToken);
    }

    public async Task<SystemUser?> GetByIdAsync(int userId, CancellationToken cancellationToken = default)
    {
        return await _context.SystemUsers.FirstOrDefaultAsync(u => u.UserId == userId, cancellationToken);
    }
    
    public async Task<SystemUser?> AddUserAsync(SystemUser newUser, CancellationToken cancellationToken = default)
    {
        _context.SystemUsers.Add(newUser);
        await _context.SaveChangesAsync(cancellationToken);
        return newUser;
    }

    public async Task<List<string>> GetUserRolesAsync(int userId, CancellationToken cancellationToken = default)
    {
        return await _context.UserRoles
            .Where(ur => ur.UserId == userId)
            .Join(_context.RolePermissions,
                ur => ur.RoleId,
                rp => rp.RoleId,
                (ur, rp) => rp.PermissionId)
            .Join(_context.Permissions,
                permissionId => permissionId,
                p => p.PermissionId,
                (permissionId, p) => p.Name)
            .ToListAsync(cancellationToken);
    }
}