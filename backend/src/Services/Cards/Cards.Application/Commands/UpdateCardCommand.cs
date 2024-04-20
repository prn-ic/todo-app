using Cards.Domain.Constants;
using MediatR;

namespace Cards.Application.Commands
{
    public class UpdateCardCommand : IRequest<int>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public CardStatuses StatusId { get; set; }
        public UpdateCardCommand(Guid id, string? name, string? description, CardStatuses? status)
        {
            Id = id;
            Name = string.IsNullOrEmpty(name) ? Name : name;
            Description = description ?? description;
            StatusId = status ?? StatusId;
        }
    }
}