using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoHub.Domain.Entities.Abstractions;

[Index(nameof(Identifier), IsUnique = true)]
[Index(nameof(LicensePlate), IsUnique = true)]
public abstract class Vehicle
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public string? Id { get; set; }

    [Column("model")]
    public string? Model { get; set; }

    [Column("year")]
    public int? Year { get; set; }

    [Column("license_plate")]
    public string? LicensePlate { get; set; }

    [Column("identifier")]
    public string? Identifier { get; set; }
}
