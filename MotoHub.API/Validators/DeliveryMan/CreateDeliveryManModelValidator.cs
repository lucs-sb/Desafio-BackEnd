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
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, "identificador"));

        RuleFor(model => model.Password)
            .NotEmpty()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, "senha"));

        RuleFor(model => model.Name)
            .NotEmpty()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, "nome"));

        RuleFor(model => model.DriverLicenseNumber)
            .NotEmpty()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, "numero_cnh"));

        RuleFor(model => model.DriverLicenseType)
            .NotEmpty()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, "tipo_cnh"))
            .Matches(@"^(?:A|B|A\+B)$")
            .WithMessage(string.Format(ApiMessage.Invalid_Warning, "tipo_cnh"));

        RuleFor(model => model.TaxNumber)
            .NotEmpty()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, "cnpj"))
            .Length(14)
            .WithMessage(string.Format(ApiMessage.Invalid_Warning, "cnpj"));

        RuleFor(model => model.DateOfBirth)
            .NotEmpty()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, "data_nascimento"))
            .Must(date =>
            {
                if (date == null) return false;
                DateTime today = DateTime.Today;
                int age = today.Year - date.Year;
                if (date.Date > today.AddYears(-age)) age--;
                return age >= 18;
            })
            .WithMessage(string.Format(ApiMessage.Invalid_Warning, "data_nascimento"));
    }
}