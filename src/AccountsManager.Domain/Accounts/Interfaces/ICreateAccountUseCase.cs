namespace AccountsManager.Domain.Accounts.Interfaces;

public interface ICreateAccountUseCase
{
    Task<Guid> Create(string name, decimal balance);
}