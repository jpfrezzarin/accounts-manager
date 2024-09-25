using AccountsManager.Domain.Common;

namespace AccountsManager.Domain.Accounts.Interfaces;

public interface IGetAllAccountsUseCase<TViewModel> where TViewModel : IViewModel
{
    Task<IEnumerable<TViewModel>> GetAll();
}