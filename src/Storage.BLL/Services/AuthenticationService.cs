using Storage.BLL.DTO.Reponses;
using Storage.BLL.DTO.Requests;
using Storage.BLL.Services.Interfaces;

namespace Storage.BLL.Services;

public class AuthenticationService : IAuthenticationService
{
    public Task<LoginResponse> Authenticate(LoginRequest request)
    {
        throw new NotImplementedException();
    }
}