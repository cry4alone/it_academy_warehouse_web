namespace Storage.BLL.DTO.Reponses;

public record AuthenticationResponse(
    int UserId,
    string Username,
    string FirstName,
    string Surname,
    string AccessToken,
    string RefreshToken);