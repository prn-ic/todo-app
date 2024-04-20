using Cards.Application.Queries;
using Cards.Domain.Entities;
using Cards.Persistense.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cards.Application.Handlers
{
    public class GetCardsHandler : IRequestHandler<GetCardsQuery, List<Card>>
    {
        private readonly AppDbContext _context;
        public GetCardsHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Card>> Handle(GetCardsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Cards.Include(x => x.Status).ToListAsync();
        }
    }
}