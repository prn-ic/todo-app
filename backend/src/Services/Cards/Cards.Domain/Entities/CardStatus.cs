using Cards.Domain.Constants;

namespace Cards.Domain.Entities
{
    public class CardStatus : BaseEntity<CardStatuses>
    {
        public required string Name { get; set; }
    }
}