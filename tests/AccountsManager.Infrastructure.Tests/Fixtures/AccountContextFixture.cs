using AccountsManager.Infrastructure.Accounts;
using Microsoft.EntityFrameworkCore;

namespace AccountsManager.Infrastructure.Tests.Fixtures;

public class AccountContextFixture : IDisposable, IAsyncDisposable
{
    public AccountContext Context { get; private set; }

    private bool _isDisposed;

    public AccountContextFixture()
    {
        var options = new DbContextOptionsBuilder<AccountContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        Context = new AccountContext(options);
    }

    ~AccountContextFixture()
    {
        Dispose(false);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_isDisposed) return;

        if (disposing)
        {
            Context.Dispose();
        }

        _isDisposed = true;
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsyncCore().ConfigureAwait(false);
        Dispose(false);
        GC.SuppressFinalize(this);
    }

    protected virtual async ValueTask DisposeAsyncCore()
    {
        await Context.DisposeAsync();
    }
}