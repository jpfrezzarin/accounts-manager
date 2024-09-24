using AccountsManager.Domain.AccountsAggr;

namespace AccountsManager.Domain.Tests.AccountsAggr;

public class AccountTest
{
    [Fact]
    public void AccountTest_InitializeWithPositiveBalance_ShouldBeCreatedWithTransaction()
    {
        var account = new Account("Sells", 12);
        
        Assert.Equal("Sells", account.Name);
        Assert.Single(account.Transactions);
        Assert.Equal(12, account.Balance);
        Assert.Equal(12, account.Transactions.First().Amount);
        Assert.True(account.Transactions.First().Income);
    }
    
    [Fact]
    public void AccountTest_PositiveAccount_BalanceShouldCalculateTransactionsAmount()
    {
        var account = new Account("Sells", 12);
        account.AddTransaction(10, "t1", true);
        account.AddTransaction(5, "t1", false);
        account.AddTransaction(2, "t1", false);
        
        Assert.Equal(15, account.Balance);
    }
    
    [Fact]
    public void AccountTest_NegativeAccount_BalanceShouldCalculateTransactionsAmount()
    {
        var account = new Account("Sells", 12);
        account.AddTransaction(10, "t1", true);
        account.AddTransaction(25, "t1", false);
        account.AddTransaction(2, "t1", false);
        
        Assert.Equal(-5, account.Balance);
    }
}