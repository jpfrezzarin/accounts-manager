namespace AccountsManager.Domain.Accounts.Interfaces;

public interface IUpdateAccountUseCase
{
    Task Update(Guid accountId, string name);
}