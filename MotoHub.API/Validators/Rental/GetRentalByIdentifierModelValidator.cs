using FluentValidation;
using MotoHub.API.Models.Rental;
using MotoHub.API.Resources;

namespace MotoHub.API.Validators.Rental;

public class GetRentalByIdentifierModelValidator : AbstractValidator<GetRentalByIdentifierModel>
{
    public GetRentalByIdentifierModelValidator()
    {
        RuleFor(x => x.Identifier)
            .NotEmpty()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, "id"));
    }
}