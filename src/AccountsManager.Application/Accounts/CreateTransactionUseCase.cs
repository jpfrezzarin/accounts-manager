using AccountsManager.Application.Accounts.Interfaces;
using AccountsManager.Application.Common;
using AccountsManager.Domain.Accounts;
using AccountsManager.Domain.Accounts.Interfaces;

namespace AccountsManager.Application.Accounts;

public class CreateTransactionUseCase(IAccountRepository accountRepository) : ICreateTransactionUseCase
{
    public async Task<Guid> Create(Guid accountId, decimal amount, string description, bool income)
    {
        var account = await accountRepository.Get(accountId) ??
                      throw new NotFoundException(nameof(Account), nameof(Account.Id), accountId);
        var transactionId = account.AddTransaction(amount, description, income);
        await accountRepository.Update(account);
        return transactionId;
    }
}