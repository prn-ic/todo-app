using Cards.Application.Queries;
using Cards.Domain.Entities;
using Cards.Persistense.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Exceptions.HttpClientExceptions;

namespace Cards.Application.Handlers
{
    public class GetCardHandler : IRequestHandler<GetCardQuery, Card>
    {
        private readonly AppDbContext _context;
        public GetCardHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Card> Handle(GetCardQuery request, CancellationToken cancellationToken)
        {
            Card card = await _context.Cards.Include(x => x.Status).FirstOrDefaultAsync(x => x.Id == request.Id)
                        ?? throw new NotFoundException("Карточка не найдена");
            
            return card;
        }
    }
}