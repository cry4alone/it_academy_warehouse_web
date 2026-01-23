using FluentValidation;
using Storage.BLL.DTO.Requests.MeltRequests;

namespace Storage.BLL.Validators;

public class CreateMeltRequestValidator : AbstractValidator<CreateMeltRequest>
{
    public CreateMeltRequestValidator()
    {
        RuleFor(x => x.ProductId)
            .NotNull().WithMessage("Product Id cannot be empty");
        RuleFor(x => x.BrandId)
            .NotNull().WithMessage("BrandId cannot be empty");
        RuleFor(x => x.MeltStatusId)
            .NotNull().WithMessage("Melt StatusId cannot be empty");
        RuleFor(x => x.ProductionDate)
            .NotNull().WithMessage("ProductionDate cannot be empty");
        RuleFor(x => x.SpecificationId)
            .NotNull().WithMessage("SpecificationId cannot be empty");
    }
}