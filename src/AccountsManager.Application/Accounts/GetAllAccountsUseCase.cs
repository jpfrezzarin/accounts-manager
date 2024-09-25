using AccountsManager.Application.Accounts.Interfaces;
using AccountsManager.Application.Accounts.ViewModels;
using AccountsManager.Domain.Accounts.Interfaces;

namespace AccountsManager.Application.Accounts;

public class GetAllAccountsUseCase(IAccountRepository accountRepository) : IGetAllAccountsUseCase<AccountOnlyViewModel>
{
    public async Task<IEnumerable<AccountOnlyViewModel>> GetAll()
    {
        return await accountRepository.GetAll();
    }
}