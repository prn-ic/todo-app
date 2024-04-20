using Cards.Domain.Constants;

namespace Cards.Domain.Models.Requests
{
    public class UpdateCardRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public CardStatuses Status { get; set; }
    }
}