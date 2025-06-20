using Mapster;
using MotoHub.Application.Resources;
using MotoHub.Domain.DTOs;
using MotoHub.Domain.DTOs.Response;
using MotoHub.Domain.Entities;
using MotoHub.Domain.Interfaces;
using MotoHub.Domain.Interfaces.Repositories;
using MotoHub.Domain.Interfaces.Repositories.Base;

namespace MotoHub.Application.Services;

public class RentalService : IRentalService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRentalRepository _rentalRepository;

    private static readonly Dictionary<int, decimal> _planPrices = new()
    {
        { 7, 30m }, { 15, 28m }, { 30, 22m }, { 45, 20m }, { 50, 18m }
    };

    public RentalService(IUnitOfWork unitOfWork, IRentalRepository rentalRepository)
    {
        _unitOfWork = unitOfWork;
        _rentalRepository = rentalRepository;
    }

    public async Task CreateAsync(RentalDTO rentalDTO)
    {
        await _unitOfWork.BeginTransactionAsync();

        try
        {
            DeliveryMan deliveryMan = await _unitOfWork.Repository<DeliveryMan>().GetByIdentifierAsync(rentalDTO.DeliveryManIdentifier!) ?? throw new KeyNotFoundException(string.Format(BusinessMessage.NotFound_Warning, "entregador"));

            if (!deliveryMan.DriverLicenseType!.Contains('A'))
                throw new InvalidOperationException(string.Format(BusinessMessage.Invalid_DeliveryMan_Warning));

            Rental? rentalOld = await _rentalRepository.GetByMotorcycleIdentifierAsync(rentalDTO.MotorcycleIdentifier!);

            if (rentalOld != null && rentalOld.ReturnDate.Date > DateTime.Now.Date)
                throw new InvalidOperationException(string.Format(BusinessMessage.Invalid_Rental_Warning));

            Rental rental = rentalDTO.Adapt<Rental>();

            await _unitOfWork.Repository<Rental>().AddAsync(rental);

            await _unitOfWork.CommitAsync();
        }
        catch
        {
            await _unitOfWork.RollbackAsync();

            throw;
        }
    }

    public async Task<RentalResponseDTO> GetByIdAsync(string identifier)
    {
        Rental rental = await _rentalRepository.GetByIdentifierAsync(identifier) ?? throw new KeyNotFoundException(string.Format(BusinessMessage.NotFound_Warning, "locação"));

        return rental.Adapt<RentalResponseDTO>();
    }

    public async Task UpdateAsync(string identifier, DateTime returnDate)
    {
        Rental rental = await _rentalRepository.GetByIdentifierAsync(identifier) ?? throw new KeyNotFoundException(string.Format(BusinessMessage.NotFound_Warning, "locação"));

        decimal pricePerDay = _planPrices[rental.Plan!.Value];
        int plannedDays = rental.Plan!.Value;
        decimal totalValue;

        if (returnDate.Date < rental.ExpectedEndDate.Date)
        {
            int usedDays = (returnDate.Date - rental.StartDate.Date).Days;

            decimal usedValue = pricePerDay * usedDays;

            totalValue = rental.Plan switch
            {
                7 => usedValue + ((plannedDays - usedDays) * pricePerDay * 0.2M),
                15 => usedValue + ((plannedDays - usedDays) * pricePerDay * 0.4M),
                _ => usedValue,
            };
        }
        else if (returnDate.Date == rental.ExpectedEndDate.Date)
        {
            totalValue = pricePerDay * plannedDays;
        }
        else
        {
            int fine = 50;

            decimal planValue = pricePerDay * plannedDays;

            int daysAfterExpectedEndDate = (returnDate.Date - rental.ExpectedEndDate.Date).Days;

            decimal totalAfterExpectedEndDate = daysAfterExpectedEndDate * pricePerDay;

            decimal totalAmountOfFees = daysAfterExpectedEndDate * fine;

            totalValue = planValue + totalAfterExpectedEndDate + totalAmountOfFees;
        }

        rental.ReturnDate = returnDate;
        rental.Value = Math.Round(totalValue, 2);

        await _unitOfWork.BeginTransactionAsync();
        try
        {
            _unitOfWork.Repository<Rental>().Update(rental);
            await _unitOfWork.CommitAsync();
        }
        catch
        {
            await _unitOfWork.RollbackAsync();
            throw;
        }
    }
}
