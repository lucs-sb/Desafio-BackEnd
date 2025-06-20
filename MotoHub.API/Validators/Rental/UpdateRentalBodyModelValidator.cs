using FluentValidation;
using MotoHub.API.Models.Rental.Body;
using MotoHub.API.Resources;

namespace MotoHub.API.Validators.Rental;

public class UpdateRentalBodyModelValidator : AbstractValidator<UpdateRentalBodyModel>
{
    public UpdateRentalBodyModelValidator()
    {
        RuleFor(x => x.ReturnDate)
            .NotEmpty()
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, "data_devolucao"))
            .GreaterThanOrEqualTo(DateTime.Now)
            .WithMessage(string.Format(ApiMessage.Date_Warning, "data_devolucao"));
    }
}
