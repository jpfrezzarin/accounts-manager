using AccountsManager.Application.Accounts.Interfaces;
using AccountsManager.Domain.Accounts;
using AccountsManager.Domain.Accounts.Interfaces;

namespace AccountsManager.Application.Accounts;

public class CreateAccountUseCase(IAccountRepository repository) : ICreateAccountUseCase
{
    public async Task<Guid> Create(string name, decimal balance)
    {
        var account = new Account(name, balance);
        await repository.Add(account);
        return account.Id;
    }
}