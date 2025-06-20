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
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, "identificador"))
            .MaximumLength(32)
            .WithMessage(model => string.Format(ApiMessage.Invalid_Warning, "identificador"));

        RuleFor(x => x.LicensePlate)
            .NotEmpty()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, "placa"));

        RuleFor(x => x.Model)
            .NotEmpty()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, "modelo"))
            .MaximumLength(50)
            .WithMessage(model => string.Format(ApiMessage.Invalid_Warning, "modelo"));

        RuleFor(x => x.Year)
            .NotNull()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, "ano"))
            .InclusiveBetween(1900, DateTime.UtcNow.Year + 1)
            .WithMessage(model => string.Format(ApiMessage.Invalid_Warning, "ano"));
    }
}
