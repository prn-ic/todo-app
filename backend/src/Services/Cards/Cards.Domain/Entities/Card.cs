using System.Text.Json.Serialization;
using Cards.Domain.Constants;

namespace Cards.Domain.Entities
{
    public class Card : BaseEntity<Guid>
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public CardStatus? Status { get; set; }
        
        [JsonIgnore]
        public CardStatuses StatusId { get; set; }
    }
}