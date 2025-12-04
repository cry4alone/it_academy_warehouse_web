namespace Storage.BLL.DTO.Reponses;

public record LoginResponse(
    int UserId,
    string Username,
    string FirstName,
    string Surname,
    string Token);