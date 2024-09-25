using AccountsManager.Domain.Common;

namespace AccountsManager.Application.Common;

public class NotFoundException(string entity, string key, object value) 
    : AccountsManagerException($"Entity {entity} was not found with {key}={value}")
{
    
}