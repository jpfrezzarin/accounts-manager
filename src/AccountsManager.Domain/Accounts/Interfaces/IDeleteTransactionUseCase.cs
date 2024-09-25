namespace AccountsManager.Domain.Accounts.Interfaces;

public interface IDeleteTransactionUseCase
{
    Task Delete(Guid accountId, Guid transactionId);
}