using AccountsManager.Domain.Common;

namespace AccountsManager.Domain.Accounts.Exceptions;

public class NegativeAmountException() : AccountsManagerException("Negative amounts are not allowed");