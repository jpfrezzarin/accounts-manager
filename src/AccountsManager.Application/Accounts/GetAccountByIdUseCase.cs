using AccountsManager.Application.Accounts.Interfaces;
using AccountsManager.Application.Accounts.ViewModels;
using AccountsManager.Application.Common;
using AccountsManager.Domain.Accounts;
using AccountsManager.Domain.Accounts.Interfaces;

namespace AccountsManager.Application.Accounts;

public class GetAccountByIdUseCase(IAccountRepository accountRepository) : IGetAccountByIdUseCase<AccountViewModel>
{
    public async Task<AccountViewModel> GetById(Guid id)
    {
        return await accountRepository.GetById(id) ?? 
               throw new NotFoundException(nameof(Account), nameof(Account.Id), id);
    }
}