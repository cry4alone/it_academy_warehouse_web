using Storage.BLL.DTO.Reponses;
using Storage.BLL.DTO.Requests;

namespace Storage.BLL.Services.Interfaces;

public interface IAuthenticationService
{
    Task<LoginResponse?> Authenticate(LoginRequest request);
}