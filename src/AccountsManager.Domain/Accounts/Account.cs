using AccountsManager.Domain.Accounts.Exceptions;
using AccountsManager.Domain.Common;

namespace AccountsManager.Domain.Accounts;

public class Account : Entity, IAggregation
{
    private readonly List<Transaction> _transactions = [];

    public Account(string name, decimal balance)
    {
        Name = name;
        AddTransaction(balance, $"Hello, {name}", true);
    }
    
    public string Name { get; set; }
    public decimal Balance => _transactions.Sum(t => t.Income ? t.Amount : t.Amount * -1);
    public IReadOnlyCollection<Transaction> Transactions => _transactions;

    public Guid AddTransaction(decimal amount, string description, bool income)
    {
        if (amount < 0) throw new NegativeAmountException();
        var transaction = new Transaction(Id, amount, description, income);
        _transactions.Add(transaction);
        return transaction.Id;
    }

    public void RemoveTransaction(Guid transactionId)
    {
        var transaction = _transactions.FirstOrDefault(t => t.Id.Equals(transactionId));
        if (transaction is null) return; 
        _transactions.Remove(transaction);
    }
}