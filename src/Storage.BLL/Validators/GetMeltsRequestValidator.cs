using FluentValidation;
using Storage.BLL.DTO.Requests.MeltRequests;

namespace Storage.BLL.Validators;

public class GetMeltsRequestValidator : AbstractValidator<GetMeltsRequest>
{
    public GetMeltsRequestValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThan(0).WithMessage("Page number must be greater than 0.");

        RuleFor(x => x.PageSize)
            .GreaterThan(0).WithMessage("Page size must be greater than 0.")
            .LessThanOrEqualTo(20).WithMessage("Page size must not exceed 20.");
    }
}