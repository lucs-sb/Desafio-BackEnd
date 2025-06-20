using FluentValidation;
using MotoHub.API.Models.DeliveryMan;
using MotoHub.API.Resources;

namespace MotoHub.API.Validators.DeliveryMan;

public class UpdateDeliveryManModelValidator : AbstractValidator<UpdateDeliveryManModel>
{
    public UpdateDeliveryManModelValidator()
    {
        RuleFor(model => model.DriverLicenseImage)
            .NotEmpty()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, "imagem_cnh"));
    }
}