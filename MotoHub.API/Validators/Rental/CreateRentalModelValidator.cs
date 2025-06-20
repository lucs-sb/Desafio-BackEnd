using FluentValidation;
using MotoHub.API.Models.Rental;

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
            .Must(date =>
            {
                return date.Date == DateTime.Today.AddDays(1);
            })
            .WithMessage("A locação deve começar no primeiro dia após a criação.");

        RuleFor(x => x.EndDate)
            .NotEmpty()
            .WithMessage("Data de término é obrigatória.")
            .GreaterThan(x => x.StartDate)
            .WithMessage("Data de término deve ser posterior à data de início.");

        RuleFor(x => x.ExpectedEndDate)
            .NotEmpty()
            .WithMessage("Data de previsão de término é obrigatória.")
            .GreaterThanOrEqualTo(x => x.StartDate)
            .WithMessage("Data de previsão de término deve ser no mínimo a data de início.");

        RuleFor(x => x.Plan)
            .NotNull()
            .WithMessage("Plano é obrigatório.")
            .Must(p => p.HasValue && _planPrices.ContainsKey(p.Value))
            .WithMessage($"Plano inválido. Os planos válidos são: {string.Join(", ", _planPrices.Keys)}");

        RuleFor(x => x.MotorcycleIdentifier)
            .NotEmpty().WithMessage("Moto obrigatória.");

        RuleFor(x => x.Identifier)
            .NotEmpty().WithMessage("Identifier obrigatória.");

        RuleFor(x => x.DeliveryManIdentifier)
            .NotEmpty().WithMessage("Entregador obrigatório.");
    }
}