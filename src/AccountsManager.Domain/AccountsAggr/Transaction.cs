using AccountsManager.Domain.Common;

namespace AccountsManager.Domain.AccountsAggr;

public class Transaction(decimal amount, string description, bool income) : Entity
{
    public decimal Amount { get; protected set; } = amount;
    public string Description { get; protected set; } = description;
    public DateTimeOffset Date { get; protected set; } = DateTimeOffset.UtcNow;
    public bool Income { get; protected set; } = income;
}