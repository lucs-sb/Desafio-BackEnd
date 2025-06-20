using FluentValidation;
using MotoHub.API.Models.Motorcycle.Body;
using MotoHub.API.Resources;

namespace MotoHub.API.Validators.Motorcycle;

public class UpdateMotorcycleBodyModelValidator : AbstractValidator<UpdateMotorcycleBodyModel>
{
    public UpdateMotorcycleBodyModelValidator()
    {
        RuleFor(x => x.LicensePlate)
            .NotEmpty()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, "placa"));
    }
}