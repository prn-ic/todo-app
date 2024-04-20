using Cards.Domain.Entities;
using MediatR;

namespace Cards.Application.Queries
{
    public class GetCardsQuery : IRequest<List<Card>>
    {
        
    }
}