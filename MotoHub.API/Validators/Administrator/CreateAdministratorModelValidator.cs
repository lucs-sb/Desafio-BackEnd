using FluentValidation;
using MotoHub.API.Models.Administrator;
using MotoHub.API.Resources;

namespace MotoHub.API.Validators.Administrator;

public class CreateAdministratorModelValidator : AbstractValidator<CreateAdministratorModel>
{
    public CreateAdministratorModelValidator()
    {
        RuleFor(model => model.Identifier)
            .NotEmpty()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, nameof(model.Identifier)));

        RuleFor(model => model.Password)
            .NotEmpty()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, nameof(model.Password)));
    }
}
