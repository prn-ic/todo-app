using MediatR;

namespace Cards.Application.Commands
{
    public class DeleteCardCommand : IRequest<int>
    {
        public Guid Id { get; set; }
    }
}