using Cards.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cards.Persistense.Configurations
{
    internal class BaseEntityConfiguration<TEntity, TIdType> where TEntity : BaseEntity<TIdType> where TIdType : struct
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder) 
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
        }
    }
}