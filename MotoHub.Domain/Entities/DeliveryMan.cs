using Microsoft.EntityFrameworkCore;
using MotoHub.Domain.Entities.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoHub.Domain.Entities;

[Table("delivery_man")]
[Index(nameof(DriverLicenseNumber), IsUnique = true)]
[Index(nameof(TaxNumber), IsUnique = true)]
public class DeliveryMan : User
{
    [Column("name")]
    public string? Name { get; set; }

    [Column("driver_license_number")]
    public string? DriverLicenseNumber { get; set; }

    [Column("driver_license_type")]
    public string? DriverLicenseType { get; set; }

    [Column("taxnumber")]
    public string? TaxNumber { get; set; }

    [Column("date_of_birth")]
    public string? DateOfBirth { get; set; }
}
