using AccountsManager.Domain.Accounts;
using AccountsManager.Infrastructure.Accounts;
using AccountsManager.Infrastructure.Tests.Fixtures;

namespace AccountsManager.Infrastructure.Tests.Accounts;

public class AccountRepositoryTest(AccountContextFixture contextFixture, MappingProfileFixture mapperFixture)
    : IClassFixture<AccountContextFixture>, IClassFixture<MappingProfileFixture>
{
    [Fact]
    public async Task AccountRepositoryTest_InsertAndGet_ShouldReturnSameAccount()
    {
        var repository = new AccountRepository(contextFixture.Context, mapperFixture.Mapper);

        var account = new Account("test", 10);
        await repository.Add(account);

        var accountFromDb = await repository.Get(account.Id);
        
        Assert.Equal(account.Id, accountFromDb!.Id);
        Assert.Equal("test", accountFromDb.Name);
        Assert.Equal(10, accountFromDb.Balance);
    }
}