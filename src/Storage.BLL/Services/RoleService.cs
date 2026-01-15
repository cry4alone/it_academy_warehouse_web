using AutoMapper;
using Storage.BLL.DTO.Requests.RoleRequests;
using Storage.BLL.DTO.Responses;
using Storage.BLL.Services.Interfaces;
using Storage.DAL.Models;
using Storage.DAL.Repositories.Interfaces;

namespace Storage.BLL.Services;

/// <inheritdoc cref="IRoleService"/>
public class RoleService : IRoleService
{
    /// <inheritdoc cref="IRoleRepository"/>
    private readonly IRoleRepository _roleRepository;
    
    /// <inheritdoc cref="IPermissionRepository"/>
    private readonly IPermissionRepository _permissionRepository;
    
    private readonly IMapper _mapper;

    /// <summary>
    /// Инициализирует новый экземпляр сервиса <see cref="RoleService"/>.
    /// </summary>
    /// <param name="roleRepository">Репозиторий для работы с ролями.</param>
    /// <param name="mapper">Маппер для преобразования объектов.</param>
    /// <param name="permissionRepository">Репозиторий для работы с разрешениями.</param>
    public RoleService(IRoleRepository roleRepository, IMapper mapper, IPermissionRepository permissionRepository)
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
        _permissionRepository = permissionRepository;
    }
    
    public async Task<List<RoleResponse>> GetAllRolesAsync()
    {
        var roles = await _roleRepository.GetAllRolesAsync();

        return _mapper.Map<List<RoleResponse>>(roles);
    }
    
    public async Task<RoleResponse> CreateRoleAsync(CreateRoleRequest createRoleRequest, CancellationToken cancellationToken = default)
    {
        var role = _mapper.Map<Role>(createRoleRequest);
        
        var createdRole = await _roleRepository.CreateRoleAsync(role, cancellationToken);
        var createdRoleResponse = _mapper.Map<RoleResponse>(createdRole);

        return createdRoleResponse;
    }
    
    public async Task UpdateRolePermissionsAsync(UpdateRolePermissionsRequest updateRolePermissionsRequest,
        CancellationToken cancellationToken = default)
    {
        var role = await _roleRepository.GetRoleByIdAsync(updateRolePermissionsRequest.RoleId, cancellationToken);
        if (role == null)
        {
            throw new KeyNotFoundException($"Role with ID {updateRolePermissionsRequest.RoleId} not found.");
        }
        
        var existingPermissionIds = await _permissionRepository.GetExistingRolePermissionsById(role.RoleId, cancellationToken);
        var permissionIdsToUpdate = updateRolePermissionsRequest.PermissionIds
            .Except(existingPermissionIds)
            .Select(p => new RolePermission
            {
                RoleId = role.RoleId,
                PermissionId = p
            })
            .ToList();
        
        await _permissionRepository.AddRolePermissionsAsync(permissionIdsToUpdate, cancellationToken);
    }
    
    public async Task<RoleResponse> GetRoleByIdAsync(int roleId, CancellationToken cancellationToken = default)
    {
        var role = await _roleRepository.GetRoleByIdAsync(roleId, cancellationToken);
        
        return role == null
            ? throw new KeyNotFoundException($"Role with ID {roleId} not found.")
            : _mapper.Map<RoleResponse>(role);
    }
}