using System.ComponentModel.DataAnnotations;

namespace AccountsManager.Infrastructure.Common;

public class EntityDao
{
    [Key]
    public Guid Id { get; set; }
}