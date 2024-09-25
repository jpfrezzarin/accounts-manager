namespace AccountsManager.Domain.Accounts.Interfaces;

public interface ICreateTransactionUseCase
{
    Task<Guid> Create(Guid accountId, decimal amount, string description, bool income);
}