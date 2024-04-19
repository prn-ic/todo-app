using Cards.Application.Commands;
using Cards.Application.Queries;
using Cards.Domain.Entities;
using Cards.Domain.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cards.WebApi.Controllers
{
    [ApiController]
    [Route("api/cards")]
    public class CardsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CardsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            List<Card> cards = await _mediator.Send(new GetCardsQuery(), cancellationToken);
            return Ok(cards);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            Card card = await _mediator.Send(new GetCardQuery() { Id = id }, cancellationToken);
            return Ok(card);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCardRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Send(new CreateCardCommand(request.Name, request.Description), cancellationToken);
            return Accepted();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCardRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateCardCommand(request.Id, request.Name, request.Description, request.Status));
            return Accepted();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteCardCommand() { Id = id }, cancellationToken);
            return Accepted();
        }
    }
}