using System.Reflection;
using AccountsManager.Domain.Common;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AccountsManager.Infrastructure.Common;

public class Repository<TEntity, TEntityDao>(AccountsManagerContext context, IMapper mapper)
    where TEntity : Entity, IAggregation
    where TEntityDao : EntityDao
{
    protected readonly IMapper Mapper = mapper;
    protected DbSet<TEntityDao> Database => context.Set<TEntityDao>();
    
    public virtual async Task Add(TEntity entity, CancellationToken cancellationToken = default)
    {
        var entityDao = Mapper.Map<TEntityDao>(entity);
        await Database.AddAsync(entityDao, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
    }
    
    public virtual async Task Update(TEntity entity, CancellationToken cancellationToken = default)
    {
        var entityDao = await Database.FindAsync([ entity.Id ], cancellationToken: cancellationToken);
        Mapper.Map(entity, entityDao);
        Database.Update(entityDao!);
        context.Entry(entityDao!).State = EntityState.Modified;
        await context.SaveChangesAsync(cancellationToken);
    }
    
    public virtual async Task Delete(TEntity entity, CancellationToken cancellationToken = default)
    {
        var entityDao = await Database.FindAsync([ entity.Id ], cancellationToken: cancellationToken);
        Mapper.Map(entity, entityDao);
        Database.Remove(entityDao!);
        await context.SaveChangesAsync(cancellationToken);
    }
}