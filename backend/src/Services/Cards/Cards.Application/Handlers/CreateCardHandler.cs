using Cards.Application.Commands;
using Cards.Domain.Entities;
using Cards.Persistense.Data;
using MediatR;

namespace Cards.Application.Handlers
{
    public class CreateCardHandler : IRequestHandler<CreateCardCommand, Card>
    {
        private readonly AppDbContext _context;
        public CreateCardHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Card> Handle(CreateCardCommand request, CancellationToken cancellationToken)
        {
            Card card = new Card()
            {
                Name = request.Name,
                Description = request.Description,
                CreatedAt = request.CreatedAt,
                StatusId = request.StatusId,
                Status = new CardStatus()
                {
                    Id = request.StatusId,
                    Name = request.StatusId.ToString()
                }
            };

            await _context.Cards.AddAsync(card, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return card;
        }
    }
}