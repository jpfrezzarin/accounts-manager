using AccountsManager.Infrastructure.Accounts.Models;
using AccountsManager.Infrastructure.Common;
using Microsoft.EntityFrameworkCore;

namespace AccountsManager.Infrastructure.Accounts;

public class AccountContext(DbContextOptions options) : AccountsManagerContext(options)
{
    public virtual DbSet<AccountDao> Accounts { get; set; }
    public virtual DbSet<TransactionDao> Transactions { get; set; }
}