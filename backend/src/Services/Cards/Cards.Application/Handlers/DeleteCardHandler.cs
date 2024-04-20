using Cards.Application.Commands;
using Cards.Domain.Entities;
using Cards.Persistense.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TodoApp.Exceptions.HttpClientExceptions;

namespace Cards.Application.Handlers
{
    public class DeleteCardHandler : IRequestHandler<DeleteCardCommand, int>
    {
        private readonly AppDbContext _context;
        public DeleteCardHandler(AppDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteCardCommand request, CancellationToken cancellationToken)
        {
            Card card = await _context.Cards.FirstOrDefaultAsync(x => x.Id == request.Id)
                        ?? throw new NotFoundException("Карточка не найдена");

            _context.Cards.Remove(card);

            return await _context.SaveChangesAsync(cancellationToken);
        }
    }
}