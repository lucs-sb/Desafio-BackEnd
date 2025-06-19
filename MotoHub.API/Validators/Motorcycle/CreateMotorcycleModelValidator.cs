using FluentValidation;
using MotoHub.API.Models.Motorcycle;
using MotoHub.API.Resources;

namespace MotoHub.API.Validators.Motorcycle;

public class CreateMotorcycleModelValidator : AbstractValidator<CreateMotorcycleModel>
{
    public CreateMotorcycleModelValidator()
    {
        RuleFor(x => x.Identifier)
            .NotEmpty()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, nameof(model.Identifier)))
            .MaximumLength(32)
            .WithMessage(model => string.Format(ApiMessage.Invalid_Warning, nameof(model.Model)));

        RuleFor(x => x.LicensePlate)
            .NotEmpty()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, nameof(model.LicensePlate)))
            .Matches("^(?=.*[A-Z0-9])[A-Z0-9]{7}$")
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, nameof(model.LicensePlate)));

        RuleFor(x => x.Model)
            .NotEmpty()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, nameof(model.Model)))
            .MaximumLength(50)
            .WithMessage(model => string.Format(ApiMessage.Invalid_Warning, nameof(model.Model)));

        RuleFor(x => x.Year)
            .NotNull()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, nameof(model.Year)))
            .InclusiveBetween(1900, DateTime.UtcNow.Year + 1)
            .WithMessage(model => string.Format(ApiMessage.Invalid_Warning, nameof(model.Year)));
    }
}
