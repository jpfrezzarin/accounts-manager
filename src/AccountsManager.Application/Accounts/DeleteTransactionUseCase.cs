using AccountsManager.Application.Accounts.Interfaces;
using AccountsManager.Application.Common;
using AccountsManager.Domain.Accounts;
using AccountsManager.Domain.Accounts.Interfaces;

namespace AccountsManager.Application.Accounts;

public class DeleteTransactionUseCase(IAccountRepository accountRepository) : IDeleteTransactionUseCase
{
    public async Task Delete(Guid accountId, Guid transactionId)
    {
        var account = await accountRepository.Get(accountId) ??
                      throw new NotFoundException(nameof(Account), nameof(Account.Id), accountId);
        account.RemoveTransaction(transactionId);
        await accountRepository.Update(account);
    }
}