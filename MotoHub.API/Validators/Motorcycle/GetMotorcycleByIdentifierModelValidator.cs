using FluentValidation;
using MotoHub.API.Models.Motorcycle;
using MotoHub.API.Resources;

namespace MotoHub.API.Validators.Motorcycle;

public class GetMotorcycleByIdentifierModelValidator : AbstractValidator<GetMotorcycleByIdentifierModel>
{
    public GetMotorcycleByIdentifierModelValidator()
    {
        RuleFor(x => x.Identifier)
            .NotEmpty()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, nameof(model.Identifier)));
    }
}
