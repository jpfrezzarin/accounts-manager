using AccountsManager.Infrastructure.Common;

namespace AccountsManager.Infrastructure.Accounts.Models;

public class AccountDao : EntityDao
{
    public string Name { get; set; }

    public virtual ICollection<TransactionDao> Transactions { get; set; } = new HashSet<TransactionDao>();
}