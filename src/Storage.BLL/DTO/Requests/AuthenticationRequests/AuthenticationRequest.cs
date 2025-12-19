namespace Storage.BLL.DTO.Requests.AuthenticationRequests;

public record AuthenticationRequest(
    string Username,
    string Password
);