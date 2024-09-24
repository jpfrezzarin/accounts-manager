using AccountsManager.Domain.Common;

namespace AccountsManager.Domain.AccountsAggr;

public class NegativeAmountException() : AccountsManagerException("Negative amounts are not allowed");