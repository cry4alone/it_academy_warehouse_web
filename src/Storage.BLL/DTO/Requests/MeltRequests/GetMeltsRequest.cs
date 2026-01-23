namespace Storage.BLL.DTO.Requests.MeltRequests;

public record GetMeltsRequest(
    int Page = 1,
    int PageSize = 20);