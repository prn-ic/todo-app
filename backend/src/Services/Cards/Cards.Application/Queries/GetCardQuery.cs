using Cards.Domain.Entities;
using MediatR;

namespace Cards.Application.Queries
{
    public class GetCardQuery : IRequest<Card>
    {
        public Guid Id { get; set; }
    }
}