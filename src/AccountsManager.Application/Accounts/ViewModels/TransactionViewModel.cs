using AccountsManager.Application.Common;

namespace AccountsManager.Application.Accounts.ViewModels;

public class TransactionViewModel : EntityViewModel
{
    public decimal Amount { get; set; }
    public string Description { get; set; } = null!;
    public DateTime Date { get; set; }
    public bool Income { get; set; }
}