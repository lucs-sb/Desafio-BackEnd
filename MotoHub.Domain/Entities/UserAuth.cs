using MotoHub.Domain.Entities.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoHub.Domain.Entities;

[Table("user_auth")]
public class UserAuth : User
{
    [Column("password")]
    public string? Password { get; set; }

    [Column("is_admin")]
    public bool IsAdmin { get; set; }
}