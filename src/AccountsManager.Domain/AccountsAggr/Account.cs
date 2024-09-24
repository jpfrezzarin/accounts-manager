using AccountsManager.Domain.Common;

namespace AccountsManager.Domain.AccountsAggr;

public class Account : Entity, IAggregation
{
    private readonly List<Transaction> _transactions = [];

    public Account(string name, decimal balance)
    {
        Name = name;
        AddTransaction(balance, $"Hello, {name}", true);
    }
    
    public string Name { get; protected set; }
    public decimal Balance 
        => _transactions.Aggregate((decimal)0, (result, transaction) 
            => transaction.Income ? result + transaction.Amount : result - transaction.Amount);
    public IReadOnlyCollection<Transaction> Transactions => _transactions.AsReadOnly();

    public void AddTransaction(decimal amount, string description, bool income)
    {
        if (amount < 0) throw new NegativeAmountException();
        _transactions.Add(new Transaction(amount, description, income));
    }
}