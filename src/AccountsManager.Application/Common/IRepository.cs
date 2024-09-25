using AccountsManager.Domain.Common;

namespace AccountsManager.Application.Common;

public interface IRepository<T> where T : IAggregation
{
    
}