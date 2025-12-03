using Storage.BLL.DTO.Reponses;

namespace Storage.BLL.Services.Interfaces;

public interface IUserService
{
    public Task<UserResponse> GetUserByIdAsync(int userId);
}