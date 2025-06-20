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
            .WithMessage(model => string.Format(ApiMessage.Require_Warning, nameof(model.ReturnDate)))
            .GreaterThanOrEqualTo(DateTime.Now)
            .WithMessage("Data de término deve ser posterior à data de início."); ;
    }
}
