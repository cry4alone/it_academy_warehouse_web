using Storage.BLL.DTO.Reponses;
using Storage.BLL.DTO.Requests;

namespace Storage.BLL.Services.Interfaces;

public interface IUserService
{
    public Task<UserResponse> GetUserByIdAsync(int userId);
    public Task<UserResponse> CreateUserAsync(CreateUserRequest createUserRequest);
}