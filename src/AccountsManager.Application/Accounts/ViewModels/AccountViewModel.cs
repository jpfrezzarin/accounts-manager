using AccountsManager.Application.Common;

namespace AccountsManager.Application.Accounts.ViewModels;

public class AccountViewModel : AccountOnlyViewModel
{
    public IEnumerable<TransactionViewModel> Transactions { get; set; } = null!;
}