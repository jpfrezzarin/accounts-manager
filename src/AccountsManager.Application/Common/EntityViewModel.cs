using AccountsManager.Domain.Common;

namespace AccountsManager.Application.Common;

public class EntityViewModel : IViewModel
{
    public Guid Id { get; set; }
}