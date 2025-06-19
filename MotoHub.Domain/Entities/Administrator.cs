using MotoHub.Domain.Entities.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoHub.Domain.Entities;

[Table("administrator")]
public class Administrator : User
{
}