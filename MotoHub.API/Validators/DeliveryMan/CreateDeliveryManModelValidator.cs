using FluentValidation;
using MotoHub.API.Models.DeliveryMan;
using MotoHub.API.Resources;

namespace MotoHub.API.Validators.DeliveryMan;

public class CreateDeliveryManModelValidator : AbstractValidator<CreateDeliveryManModel>
{
    public CreateDeliveryManModelValidator()
    {
        RuleFor(model => model.Identifier)
            .NotEmpty()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, nameof(model.Identifier)));

        RuleFor(model => model.Password)
            .NotEmpty()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, nameof(model.Password)));

        RuleFor(model => model.Name)
            .NotEmpty()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, nameof(model.Name)));

        RuleFor(model => model.DriverLicenseNumber)
            .NotEmpty()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, nameof(model.DriverLicenseNumber)));

        RuleFor(model => model.DriverLicenseType)
            .NotEmpty()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, nameof(model.DriverLicenseType)))
            .Matches(@"^(?:A|B|A\+B)$")
            .WithMessage("Tipo de CNH inválido. Apenas 'A', 'B' ou 'A+B'."); ;

        RuleFor(model => model.TaxNumber)
            .NotEmpty()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, nameof(model.TaxNumber)));

        RuleFor(model => model.DateOfBirth)
            .NotEmpty()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, nameof(model.DateOfBirth)));
    }
}