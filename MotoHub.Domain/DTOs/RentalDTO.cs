namespace MotoHub.Domain.DTOs
{
    public record RentalDTO (string Identifier, 
        string DeliveryManIdentifier, 
        string MotorcycleIdentifier, 
        DateTime StartDate, 
        DateTime EndDate, 
        DateTime ExpectedEndDate, 
        int Plan)
    {
    }
}
