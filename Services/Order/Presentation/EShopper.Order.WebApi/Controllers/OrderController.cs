using EShopper.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using EShopper.Order.Application.Features.Mediator.Commands.OrderCommands;
using EShopper.Order.Application.Features.Mediator.Handlers.OrderHandlers;
using EShopper.Order.Application.Features.Mediator.Queries.OrderQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShopper.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> OrderList()
        {
            var values = await _mediator.Send(new GetOrderQuery());
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> OrderList(int id)
        {
            var values = await _mediator.Send(new GetOrderByIdQuery(id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sipariş başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveOrder(int id)
        {
            await _mediator.Send(new RemoveOrderCommand(id));
            return Ok("Sipariş başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> RemoveOrder(UpdateOrderCommand command)
        {
            await _mediator.Send(command);
            return Ok("Sipariş başarıyla güncellendi");
        }
    }
}
