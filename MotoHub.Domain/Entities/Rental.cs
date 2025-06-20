using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoHub.Domain.Entities;

[Table("rental")]
public class Rental
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public int Id { get; set; }

    [Column("identifier")]
    public string? Identifier { get; set; }

    [Column("start_date")]
    public DateTime StartDate { get; set; }

    [Column("end_date")]
    public DateTime EndDate { get; set; }

    [Column("expected_end_date")]
    public DateTime ExpectedEndDate { get; set; }

    [Column("motorcycle_identifier")]
    public string? MotorcycleIdentifier { get; set; }

    [Column("delivery_man_identifier")]
    public string? DeliveryManIdentifier { get; set; }

    [Column("plan")]
    public int? Plan { get; set; }

    [Column("value")]
    public decimal? Value { get; set; }

    [Column("return_date")]
    public DateTime ReturnDate { get; set; }
}
