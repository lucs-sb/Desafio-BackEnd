using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoHub.Domain.Entities.Abstractions;

[Index(nameof(Identifier), IsUnique = true)]
public abstract class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Column("id")]
    public Guid? Id { get; set; }

    [Column("identifier")]
    public string? Identifier { get; set; }
}