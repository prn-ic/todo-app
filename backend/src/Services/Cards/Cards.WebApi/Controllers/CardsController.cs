using Cards.Application.Commands;
using Cards.Application.Queries;
using Cards.Domain.Entities;
using Cards.Domain.Models.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TodoApp.Extensions.RequestModels;
using TodoApp.Responses;

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

        /// <summary>
        /// Эндпоинт для получения всех карт с задачами
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Возвращает список карточек</response>
        [HttpGet]
        [ProducesResponseType(typeof(OkResponseResult<List<Card>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(CancellationToken cancellationToken)
        {
            List<Card> cards = await _mediator.Send(new GetCardsQuery(), cancellationToken);
            return ServerResponse.OkResult(cards);
        }

        /// <summary>
        /// Эндпоинт для получения определенной карточки с задачей
        /// </summary>
        /// <param name="id">Идентификатор карточки</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(OkResponseResult<Card>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
        {
            Card card = await _mediator.Send(new GetCardQuery() { Id = id }, cancellationToken);
            return ServerResponse.OkResult(card);
        }

        /// <summary>
        /// Эндпоинт для добавления карточки с задачей
        /// </summary>
        /// <param name="request">Модель задачи</param>
        /// <param name="cancellationToken"></param>
        /// <response code="202">Добавляет карточку с задачей</response>
        [HttpPost]
        [ProducesResponseType(typeof(OkResponseResult<string>), StatusCodes.Status202Accepted)]
        public async Task<IActionResult> Create(CreateCardRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Send(new CreateCardCommand(request.Name, request.Description), cancellationToken);
            return Accepted();
        }

        /// <summary>
        /// Эндпоинт для обновления карточки с задачей
        /// </summary>
        /// <param name="request">Обновленная модель задачи</param>
        /// <param name="cancellationToken"></param>
        /// <response code="202">Обновляет карточку с задачей</response>
        /// <response code="404">Возвращает ошибку о том, что карточка не найдена</response>
        [HttpPut]
        [ProducesResponseType(typeof(OkResponseResult<string>), StatusCodes.Status202Accepted)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(UpdateCardRequest request, CancellationToken cancellationToken)
        {
            await _mediator.Send(new UpdateCardCommand(request.Id, request.Name, request.Description, request.Status));
            return Accepted();
        }

        /// <summary>
        /// Эндпоинт для удаления карточки с задачей
        /// </summary>
        /// <param name="id">Идентификатор карточки</param>
        /// <param name="cancellationToken"></param>
        /// <response code="202">Удаляет карточку с задачей</response>
        /// <response code="404">Возвращает ошибку о том, что карточка не найдена</response>
        [HttpDelete]
        [ProducesResponseType(typeof(OkResponseResult<string>), StatusCodes.Status202Accepted)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteCardCommand() { Id = id }, cancellationToken);
            return Accepted();
        }
    }
}