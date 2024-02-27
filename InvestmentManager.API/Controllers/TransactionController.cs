using InvestmentManager.Application.Commands;
using InvestmentManager.Application.Queries;
using InvestmentManager.Application.Queries.Transaction.GetTransactionById;
using InvestmentManager.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InvestmentManager.API.Controllers
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

        [HttpGet("product/{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> GetTransactionByProductIdAsync(Guid id)
        {
            var getTransactionByProductIdQuery = new GetTransactionByProductIdQuery(id);

            var investment = await _mediator.Send(getTransactionByProductIdQuery);

            if (investment == null)
                return NotFound();

            return Ok(investment);
        }

        [HttpGet("operationType/{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> GetTransactionByOperationIdAsync(Guid id)
        {
            var getTransactionByOperationIdQuery = new GetTransactionByOperationIdQuery(id);

            var investment = await _mediator.Send(getTransactionByOperationIdQuery);

            if (investment == null)
                return NotFound();

            return Ok(investment);
        }

        [HttpGet("statement")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult> GetTransactionByUserIdAsync()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "UserId");
            if (userIdClaim != null)
            {
                Guid.TryParse(userIdClaim.Value, out var userId);

                var getTransactionByUserIdQuery = new GetTransactionByUserIdQuery(userId);

                var investment = await _mediator.Send(getTransactionByUserIdQuery);

                if (investment == null)
                    return NotFound();

                return Ok(investment);
            }
            return BadRequest("User ID não identificado"); 
        }

        [HttpGet("checkBalance")]
        [Authorize(Roles = "Customer")]
        public async Task<ActionResult> CheckBalanceAsync()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "UserId");
            if (userIdClaim != null)
            {
                Guid.TryParse(userIdClaim.Value, out var userId);
                var checkBalanceQuery = new CheckBalanceQuery(userId);

                var investment = await _mediator.Send(checkBalanceQuery);

                if (investment == null)
                    return NotFound();

                return Ok(investment);
            }
            return BadRequest("User ID não identificado");
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
