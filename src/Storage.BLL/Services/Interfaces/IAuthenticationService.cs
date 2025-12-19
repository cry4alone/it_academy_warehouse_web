using Storage.BLL.DTO.Reponses;
using Storage.BLL.DTO.Requests.AuthenticationRequests;

namespace Storage.BLL.Services.Interfaces;

public interface IAuthenticationService
{
    Task<AuthenticationResponse?> Authenticate(AuthenticationRequest request, CancellationToken cancellationToken = default);
    Task<AuthenticationResponse?> RefreshToken(RefreshTokenRequest refreshToken, CancellationToken cancellationToken = default);
    Task Logout(RefreshTokenRequest refreshToken, CancellationToken cancellationToken = default);
}