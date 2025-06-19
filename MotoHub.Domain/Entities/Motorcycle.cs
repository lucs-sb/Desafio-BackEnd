using MotoHub.Domain.Entities.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoHub.Domain.Entities;

[Table("motorcycle")]
public class Motorcycle : Vehicle
{
}
