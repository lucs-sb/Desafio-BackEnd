using Microsoft.EntityFrameworkCore;
using MotoHub.Domain.Entities;

namespace MotoHub.Domain.Repository;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Administrator> Administrator { get; set; }
    public DbSet<DeliveryMan> DeliveryMen { get; set; }
    public DbSet<Motorcycle> Motorcycles { get; set; }
    public DbSet<Rental> Rentals { get; set; }
}
