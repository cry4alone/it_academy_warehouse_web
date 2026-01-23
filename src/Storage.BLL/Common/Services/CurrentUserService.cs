using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Storage.DAL.Models;
using Storage.DAL.Repositories.Interfaces;
using Storage.BLL.Common.Services.Interfaces;

namespace Storage.BLL.Common.Services;

/// <inheritdoc cref="ICurrentUserService" />
public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IUserRepository _userRepository;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository)
    {
        _httpContextAccessor = httpContextAccessor;
        _userRepository = userRepository;
    }

    
    public int UserId => Convert.ToInt32(_httpContextAccessor.HttpContext.User.Claims
        .First(x => x.Type == ClaimTypes.NameIdentifier).Value);
    
    public async Task<SystemUser?> GetCurrentUserAsync()
    {
        return await _userRepository.GetByIdAsync(UserId);
    }
}