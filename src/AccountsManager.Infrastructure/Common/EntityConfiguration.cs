using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AccountsManager.Infrastructure.Common;

public class EntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : EntityDao
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(e => e.Id);
    }
}