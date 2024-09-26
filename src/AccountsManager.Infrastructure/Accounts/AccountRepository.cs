using AccountsManager.Application.Accounts.Interfaces;
using AccountsManager.Application.Accounts.ViewModels;
using AccountsManager.Domain.Accounts;
using AccountsManager.Infrastructure.Accounts.Models;
using AccountsManager.Infrastructure.Common;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AccountsManager.Infrastructure.Accounts;

public class AccountRepository(AccountContext context, IMapper mapper) : 
    Repository<Account, AccountDao>(context, mapper), IAccountRepository
{
    public async Task<AccountViewModel?> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        var dao = await Database.Include(x => x.Transactions)
            .AsNoTracking()
            .Where(a => a.Id.Equals(id))
            .Select(a => new AccountViewModel
            {
                Id = a.Id,
                Name = a.Name,
                Balance = (decimal)a.Transactions.Sum(t => t.Income ? (double)t.Amount : (double)(-t.Amount)),
                Transactions = a.Transactions.OrderByDescending(t => t.Date).Select(t => new TransactionViewModel
                {
                    Id = t.Id,
                    Amount = t.Amount,
                    Date = t.Date,
                    Description = t.Description,
                    Income = t.Income
                })
            })
            .FirstOrDefaultAsync(cancellationToken);
        return dao;
    }

    public async Task<IEnumerable<AccountOnlyViewModel>> GetAll(CancellationToken cancellationToken = default)
    {
        var views = await Database.Include(x => x.Transactions)
            .AsNoTracking()
            .Select(a => new AccountOnlyViewModel
            {
                Id = a.Id,
                Name = a.Name,
                Balance = (decimal)a.Transactions.Sum(t => t.Income ? (double)t.Amount : (double)(-t.Amount))
            })
            .ToListAsync(cancellationToken);
        return views;
    }    
    
    public async Task<Account?> Get(Guid id, CancellationToken cancellationToken = default)
    {
        var dao = await Database.Include(x => x.Transactions)
            .FirstOrDefaultAsync(a => a.Id.Equals(id), cancellationToken);
        return Mapper.Map<Account>(dao);
    }

    public override async Task Update(Account entity, CancellationToken cancellationToken = default)
    {
        var entityDao = await Database.FindAsync([ entity.Id ], cancellationToken: cancellationToken);
        var transactionsSnapshot = entityDao!.Transactions.ToList();
        Mapper.Map(entity, entityDao);
        Database.Update(entityDao!);
        context.Entry(entityDao!).State = EntityState.Modified;
        foreach (var transactionDao in entityDao!.Transactions.Where(t => !transactionsSnapshot.Any(tt => t.Id.Equals(tt.Id))))
        {
            context.Entry(transactionDao).State = EntityState.Added;
        }
        foreach (var transactionDao in transactionsSnapshot.Where(t => !entityDao!.Transactions.Any(tt => t.Id.Equals(tt.Id))))
        {
            context.Entry(transactionDao).State = EntityState.Deleted;
        }
        await context.SaveChangesAsync(cancellationToken);
    }
}