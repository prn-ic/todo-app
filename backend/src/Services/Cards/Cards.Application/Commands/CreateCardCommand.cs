using Cards.Domain.Constants;
using Cards.Domain.Entities;
using MediatR;

namespace Cards.Application.Commands
{
    public class CreateCardCommand : IRequest<Card>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; }
        public CardStatuses StatusId { get; }
        public CreateCardCommand(string name, string? description)
        {
            Name = name;
            Description = description;
            CreatedAt = DateTime.UtcNow;
            StatusId = CardStatuses.NotDone;
        }
    }
}