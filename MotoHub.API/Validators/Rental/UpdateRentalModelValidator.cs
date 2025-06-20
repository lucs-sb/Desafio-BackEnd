using FluentValidation;
using MotoHub.API.Models.Rental;
using MotoHub.API.Resources;

namespace MotoHub.API.Validators.Rental;

public class UpdateRentalModelValidator : AbstractValidator<UpdateRentalModel>
{
    public UpdateRentalModelValidator()
    {
        RuleFor(x => x.Identifier)
            .NotEmpty()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, "id"));

        RuleFor(model => model.Body!)
            .NotNull()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, nameof(model.Body)))
            .SetValidator(model => new UpdateRentalBodyModelValidator())
            .OverridePropertyName(string.Empty);
    }
}
