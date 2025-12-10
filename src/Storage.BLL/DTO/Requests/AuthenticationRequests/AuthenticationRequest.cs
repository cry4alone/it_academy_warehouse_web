namespace Storage.BLL.DTO.Requests;

public record AuthenticationRequest(
    string Username,
    string Password
);