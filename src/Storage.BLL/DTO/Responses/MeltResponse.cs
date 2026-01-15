namespace Storage.BLL.DTO.Reponses;

/// <summary>
/// DTO — ответ с информацией о плавке (melt): идентификатор, дата производства,
/// статус, название спецификации и марка.
/// </summary>
public record MeltResponse(
    int MeltId,
    DateTime ProductionDate,
    string MeltStatus,
    string SpecificationName,
    string Brand);