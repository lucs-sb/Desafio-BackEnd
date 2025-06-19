using MotoHub.Domain.Entities.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoHub.Domain.Entities;

[Table("administradors")]
public class Administrador : User
{
}