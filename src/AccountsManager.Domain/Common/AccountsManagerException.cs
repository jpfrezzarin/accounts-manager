namespace AccountsManager.Domain.Common;

public class AccountsManagerException : Exception
{
    protected AccountsManagerException()
    {
    }

    protected AccountsManagerException(string message)
        : base(message)
    {
    }

    protected AccountsManagerException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}