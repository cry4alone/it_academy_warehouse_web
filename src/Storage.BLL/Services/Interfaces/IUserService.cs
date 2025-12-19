using Storage.BLL.DTO.Reponses;
using Storage.BLL.DTO.Requests;
using System.Threading;
using Storage.BLL.DTO.Requests.UserRequests;

namespace Storage.BLL.Services.Interfaces;

public interface IUserService
{
    public Task<UserResponse> GetUserByIdAsync(int userId, CancellationToken cancellationToken = default);
    public Task<UserResponse> CreateUserAsync(CreateUserRequest createUserRequest, CancellationToken cancellationToken = default);
}