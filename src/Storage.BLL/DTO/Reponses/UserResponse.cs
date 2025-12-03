namespace Storage.BLL.DTO.Reponses;

public record UserResponse(
    int UserId,
    string UserName,
    string Surname,
    string FirstName,
    string MiddleName);