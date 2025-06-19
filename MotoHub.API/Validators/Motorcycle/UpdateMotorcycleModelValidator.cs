using FluentValidation;
using MotoHub.API.Models.Motorcycle;
using MotoHub.API.Resources;

namespace MotoHub.API.Validators.Motorcycle;

public class UpdateMotorcycleModelValidator : AbstractValidator<UpdateMotorcycleModel>
{
    public UpdateMotorcycleModelValidator()
    {
        RuleFor(x => x.Identifier)
            .NotEmpty()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, nameof(model.Identifier)));

        RuleFor(model => model.Body!)
            .NotNull()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, nameof(model.Body)))
            .SetValidator(model => new UpdateMotorcycleBodyModelValidator())
            .OverridePropertyName(string.Empty);
    }
}
