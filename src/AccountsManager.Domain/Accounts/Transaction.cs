using AccountsManager.Domain.Common;

namespace AccountsManager.Domain.Accounts;

public class Transaction(Guid accountId, decimal amount, string description, bool income) : Entity
{
    public Guid AccountId { get; protected set; } = accountId;
    public decimal Amount { get; protected set; } = amount;
    public string Description { get; protected set; } = description;
    public DateTime Date { get; protected set; } = DateTime.UtcNow;
    public bool Income { get; protected set; } = income;
}