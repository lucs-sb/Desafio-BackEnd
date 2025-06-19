using FluentValidation;
using MotoHub.API.Models.Auth;
using MotoHub.API.Resources;

namespace MotoHub.API.Validators.Auth;

public class LoginModelValidator : AbstractValidator<LoginModel>
{
    public LoginModelValidator()
    {
        RuleFor(model => model.Identifier)
            .NotEmpty()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, nameof(model.Identifier)));

        RuleFor(model => model.Password)
            .NotEmpty()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, nameof(model.Password)));
    }
}
