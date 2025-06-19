using FluentValidation;
using MotoHub.API.Models.Administrador;
using MotoHub.API.Resources;

namespace MotoHub.API.Validators.Administrador;

public class CreateAdministradorModelValidator : AbstractValidator<CreateAdministradorModel>
{
    public CreateAdministradorModelValidator()
    {
        RuleFor(model => model.Identifier)
            .NotEmpty()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, nameof(model.Identifier)));

        RuleFor(model => model.Password)
            .NotEmpty()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, nameof(model.Password)));
    }
}
