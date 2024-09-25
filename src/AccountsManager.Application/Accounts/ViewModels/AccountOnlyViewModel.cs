using AccountsManager.Application.Common;

namespace AccountsManager.Application.Accounts.ViewModels;

public class AccountOnlyViewModel : EntityViewModel
{
    public string Name { get; set; } = null!;
    public decimal Balance { get; set; }
}