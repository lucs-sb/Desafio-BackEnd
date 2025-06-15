using MongoDB.Bson.Serialization.Attributes;

namespace MotoHub.Domain.Entities
{
    public class Rental
    {
        [BsonId]
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ExpectedEndDate { get; set; }
        public string MotorcycleIdentifier { get; set; }
        public string DeliveryManIdentifier { get; set; }
        public int Plan { get; set; }
    }
}
