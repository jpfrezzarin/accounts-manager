using AccountsManager.Domain.Common;

namespace AccountsManager.Domain.Accounts.Interfaces;

public interface IGetAccountByIdUseCase<TViewModel> where TViewModel : IViewModel
{
    Task<TViewModel> GetById(Guid id);
}