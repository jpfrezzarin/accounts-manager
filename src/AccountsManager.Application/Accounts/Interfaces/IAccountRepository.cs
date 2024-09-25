using AccountsManager.Application.Accounts.ViewModels;
using AccountsManager.Application.Common;
using AccountsManager.Domain.Accounts;

namespace AccountsManager.Application.Accounts.Interfaces;

public interface IAccountRepository : IRepository<Account>
{
    Task<AccountViewModel?> GetById(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<AccountOnlyViewModel>> GetAll(CancellationToken cancellationToken = default);
    Task<Account?> Get(Guid id, CancellationToken cancellationToken = default);
    Task Add(Account account, CancellationToken cancellationToken = default);
    Task Update(Account account, CancellationToken cancellationToken = default);
}