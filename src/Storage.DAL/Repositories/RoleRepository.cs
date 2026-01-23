using Microsoft.EntityFrameworkCore;
using Storage.DAL.Models;
using Storage.DAL.Repositories.Interfaces;

namespace Storage.DAL.Repositories;

/// <inheritdoc cref="IRoleRepository" />
public class RoleRepository : IRoleRepository
{
    private readonly WarehouseContext _context;

    /// <summary>
    /// Создаёт экземпляр <see cref="RoleRepository"/>, использующий указанный контекст хранилища.
    /// </summary>
    /// <param name="context">Экземпляр <see cref="WarehouseContext"/>, через который выполняются операции с БД.</param>
    public RoleRepository(WarehouseContext context)
    {
        _context = context;
    }

    public async Task<List<Role>> GetAllRolesAsync()
    {
        return await _context.Roles.ToListAsync();
    }

    public async Task<Role> CreateRoleAsync(Role role, CancellationToken cancellationToken = default)
    {
        _context.Roles.Add(role);
        await _context.SaveChangesAsync(cancellationToken);
        return role;
    }

    public async Task<Role> UpdateRoleAsync(Role role, CancellationToken cancellationToken = default)
    {
        _context.Roles.Update(role);
        await _context.SaveChangesAsync(cancellationToken);
        return role;
    }

    public async Task<Role?> GetRoleByIdAsync(int roleId, CancellationToken cancellationToken = default)
    {
        return await _context.Roles.FirstOrDefaultAsync(r => r.RoleId == roleId,
            cancellationToken: cancellationToken);
    }
}