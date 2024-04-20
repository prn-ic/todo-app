using Cards.Domain.Constants;
using Cards.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cards.Persistense.Configurations
{
    internal class CardStatusConfiguration : BaseEntityConfiguration<CardStatus, CardStatuses>
    {
        public override void Configure(EntityTypeBuilder<CardStatus> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Id).HasConversion<int>();

            builder.HasData(Enum.GetValues<CardStatuses>().Cast<CardStatuses>().Select(x => new CardStatus() { Id = x, Name = x.ToString().ToLower() }));
        }
    }
}