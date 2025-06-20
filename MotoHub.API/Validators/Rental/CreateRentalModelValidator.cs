using FluentValidation;
using MotoHub.API.Models.Rental;
using MotoHub.API.Resources;

namespace MotoHub.API.Validators.Rental;

public class CreateRentalModelValidator : AbstractValidator<CreateRentalModel>
{
    private static readonly Dictionary<int, decimal> _planPrices = new()
    {
        { 7, 30m }, { 15, 28m }, { 30, 22m }, { 45, 20m }, { 50, 18m }
    };

    public CreateRentalModelValidator()
    {
        RuleFor(x => x.StartDate)
            .NotEmpty()
            .WithMessage(string.Format(ApiMessage.Require_Warning, "data_inicio"))
            .Must(date =>
            {
                return date.Date == DateTime.Today.AddDays(1);
            })
            .WithMessage(ApiMessage.Location_StartDate_Warning);

        RuleFor(x => x.EndDate)
            .NotEmpty()
            .WithMessage(string.Format(ApiMessage.Require_Warning, "data_termino"))
            .GreaterThan(x => x.StartDate)
            .WithMessage(string.Format(ApiMessage.Invalid_Warning, "data_termino"));

        RuleFor(x => x.ExpectedEndDate)
            .NotEmpty()
            .WithMessage(string.Format(ApiMessage.Require_Warning, "data_previsao_termino"))
            .GreaterThanOrEqualTo(x => x.StartDate)
            .WithMessage(string.Format(ApiMessage.Invalid_Warning, "data_previsao_termino"));

        RuleFor(x => x.Plan)
            .NotNull()
            .WithMessage(string.Format(ApiMessage.Require_Warning, "plano"))
            .Must(p => p.HasValue && _planPrices.ContainsKey(p.Value))
            .WithMessage(string.Format(ApiMessage.Invalid_Warning, "plano"));

        RuleFor(x => x.MotorcycleIdentifier)
            .NotEmpty()
            .WithMessage(string.Format(ApiMessage.Require_Warning, "moto_id"));

        RuleFor(x => x.Identifier)
            .NotEmpty()
            .WithMessage(string.Format(ApiMessage.Require_Warning, "identificador"));

        RuleFor(x => x.DeliveryManIdentifier)
            .NotEmpty()
            .WithMessage(string.Format(ApiMessage.Require_Warning, "entregador_id"));
    }
}