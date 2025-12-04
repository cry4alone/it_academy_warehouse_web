namespace Storage.BLL.DTO.Requests;

public record LoginRequest(
    string Username,
    string Password
);