namespace Storage.BLL.DTO.Reponses;

public record MeltResponse(
    int MeltId,
    DateTime ProductionDate,
    string MeltStatus,
    string SpecificationName,
    string Brand);