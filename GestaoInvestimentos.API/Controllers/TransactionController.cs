using GestaoInvestimentos.Application.Commands;
using GestaoInvestimentos.Application.Queries;
using GestaoInvestimentos.Application.Queries.Transaction.GetTransactionById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestaoInvestimentos.API.Controllers
{
    [ApiController]
    [Route("api/transactions")]
    public class TransactionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> GetTransactionByIdQuery(Guid id)
        {
            var getTransactionByIdQuery = new GetTransactionByIdQuery(id);

            var investment = await _mediator.Send(getTransactionByIdQuery);

            if (investment == null)
                return NotFound();

            return Ok(investment);
        }

        [HttpGet("user/{id}")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult> GetTransactionByUserIdAsync(Guid id)
        {
            var getTransactionByUserIdQuery = new GetTransactionByUserIdQuery(id);

            var investment = await _mediator.Send(getTransactionByUserIdQuery);

            if (investment == null)
                return NotFound();

            return Ok(investment);
        }

        [HttpGet("product/{id}")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult> GetTransactionByProductIdAsync(Guid id)
        {
            var getTransactionByProductIdQuery = new GetTransactionByProductIdQuery(id);

            var investment = await _mediator.Send(getTransactionByProductIdQuery);

            if (investment == null)
                return NotFound();

            return Ok(investment);
        }

        [HttpGet("operationType/{id}")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult> GetTransactionByOperationIdAsync(Guid id)
        {
            var getTransactionByOperationIdQuery = new GetTransactionByOperationIdQuery(id);

            var investment = await _mediator.Send(getTransactionByOperationIdQuery);

            if (investment == null)
                return NotFound();

            return Ok(investment);
        }

        [HttpPost("buy")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult> BuyInvestment([FromBody] CreateTransactionCommand command)
        {
            try
            {
                var id = await _mediator.Send(command);

                return CreatedAtAction(nameof(GetTransactionByIdQuery), new { id }, command);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("sell")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult> SellInvestment([FromBody] RemoveTransactionCommand command)
        {
            try
            {
                var id = await _mediator.Send(command);

                return CreatedAtAction(nameof(GetTransactionByIdQuery), new { id }, command);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
