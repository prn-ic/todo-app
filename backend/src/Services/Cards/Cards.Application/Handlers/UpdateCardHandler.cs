using Cards.Application.Commands;
using Cards.Domain.Constants;
using Cards.Domain.Entities;
using Cards.Persistense.Data;
using TodoApp.Exceptions.HttpClientExceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cards.Application.Handlers
{
    public class UpdateCardHandler : IRequestHandler<UpdateCardCommand, int>
    {
        private readonly AppDbContext _context;
        public UpdateCardHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(UpdateCardCommand request, CancellationToken cancellationToken)
        {
            Card card = await _context.Cards.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken)
                        ?? throw new NotFoundException("Карточка не найдена");

            card.Name = request.Name!;
            card.Description = request.Description;
            card.StatusId = request.StatusId;
            card.Status = new CardStatus()
            {
                Id = request.StatusId,
                Name = ((CardStatuses)request.StatusId).ToString()
            };

            _context.Cards.Update(card);
            

            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}