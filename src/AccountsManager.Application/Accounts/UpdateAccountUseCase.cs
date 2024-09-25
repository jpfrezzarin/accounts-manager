using AccountsManager.Application.Accounts.Interfaces;
using AccountsManager.Application.Common;
using AccountsManager.Domain.Accounts;
using AccountsManager.Domain.Accounts.Interfaces;

namespace AccountsManager.Application.Accounts;

public class UpdateAccountUseCase(IAccountRepository accountRepository) : IUpdateAccountUseCase
{
    public async Task Update(Guid accountId, string name)
    {
        var account = await accountRepository.Get(accountId) ??
                      throw new NotFoundException(nameof(Account), nameof(Account.Id), accountId);
        account.Name = name;
        await accountRepository.Update(account);
    }
}