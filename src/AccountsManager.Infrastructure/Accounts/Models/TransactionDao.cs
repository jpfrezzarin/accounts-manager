using System.ComponentModel.DataAnnotations.Schema;
using AccountsManager.Infrastructure.Common;

namespace AccountsManager.Infrastructure.Accounts.Models;

public class TransactionDao : EntityDao
{
    public Guid AccountId { get; set; }
    public decimal Amount { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public bool Income { get; set; }
    
    [ForeignKey(nameof(AccountId))]
    public virtual AccountDao Account { get; set; }
}