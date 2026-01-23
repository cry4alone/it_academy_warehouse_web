using Microsoft.EntityFrameworkCore;
using Storage.DAL.Models;
using Storage.DAL.Repositories.Interfaces;

namespace Storage.DAL.Repositories;

/// <inheritdoc cref="IPermissionRepository"/>
public class PermissionRepository : IPermissionRepository
{
    private readonly WarehouseContext _context;
    
    public PermissionRepository(WarehouseContext warehouseContext)
    {
        _context = warehouseContext;
    }
    
    public async Task<List<Permission>> GetAllAsync()
    {
        return await _context.Permissions.ToListAsync();
    }

    public async Task<Permission?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await _context.Permissions.FirstOrDefaultAsync(p => p.PermissionId == id,
            cancellationToken: cancellationToken);
    }

    public async Task AddRolePermissionsAsync(List<RolePermission> rolePermission, CancellationToken cancellationToken = default)
    {
        _context.RolePermissions.AddRange(rolePermission);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<HashSet<int>> GetExistingIdsAsync(List<int> permissionIds, CancellationToken cancellationToken = default)
    {
        var existingIds = await _context.Permissions
            .Where(p => permissionIds.Contains(p.PermissionId))
            .Select(p => p.PermissionId)
            .ToListAsync(cancellationToken: cancellationToken);
        
        return existingIds.ToHashSet();
    }

    public async Task<HashSet<int>> GetExistingRolePermissionsById(int id, CancellationToken cancellationToken = default)
    {
        var existingRolePermissions = await _context.RolePermissions
            .Where(rp => rp.RoleId == id)
            .Select(rp => rp.PermissionId)
            .ToListAsync(cancellationToken: cancellationToken);
        
        return existingRolePermissions.ToHashSet();
    }
}