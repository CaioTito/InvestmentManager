using InvestmentManager.Application.Commands;
using InvestmentManager.Application.Queries;
using InvestmentManager.Application.Queries.Transaction.GetTransactionById;
using InvestmentManager.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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

        /// <summary>
        /// Retorna a transação de acordo com o digitado no id
        /// </summary>
        /// <param name="id">ID da transação</param>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(TransactionViewModel))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(NotFoundResult))]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> GetTransactionByIdQuery(Guid id)
        {
            var getTransactionByIdQuery = new GetTransactionByIdQuery(id);

            var investment = await _mediator.Send(getTransactionByIdQuery);

            if (investment == null)
                return NotFound();

            return Ok(investment);
        }

        /// <summary>
        /// Retorna as transações de acordo com o digitado no id do produto
        /// </summary>
        /// <param name="id">ID do produto</param>
        [HttpGet("product/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<TransactionViewModel>))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(NotFoundResult))]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> GetTransactionByProductIdAsync(Guid id)
        {
            var getTransactionByProductIdQuery = new GetTransactionByProductIdQuery(id);

            var investment = await _mediator.Send(getTransactionByProductIdQuery);

            if (investment == null)
                return NotFound();

            return Ok(investment);
        }

        /// <summary>
        /// Retorna as transações de acordo com o digitado no id do tipo de operação
        /// </summary>
        /// <param name="id">ID do tipo de operação</param>
        [HttpGet("operationType/{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<TransactionViewModel>))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(NotFoundResult))]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> GetTransactionByOperationIdAsync(Guid id)
        {
            var getTransactionByOperationIdQuery = new GetTransactionByOperationIdQuery(id);

            var investment = await _mediator.Send(getTransactionByOperationIdQuery);

            if (investment == null)
                return NotFound();

            return Ok(investment);
        }

        /// <summary>
        /// Retorna as transações do usuario recuperando seu ID pelo Token
        /// </summary>
        [HttpGet("statement")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<TransactionViewModel>))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(NotFoundResult))]
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
            return BadRequest("Error in UserId identification");
        }

        /// <summary>
        /// Retorna os saldos do usuario recuperando seu ID pelo Token
        /// </summary>
        [HttpGet("checkBalance")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CheckBalanceViewModel))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(NotFoundResult))]
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
            return BadRequest("Error in UserId identification");
        }

        /// <summary>
        /// Operação para compra de um produto
        /// </summary>
        /// <param name="command">Ids de Produto, tipo de operação e valor</param>
        [HttpPost("buy")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestResult))]
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

        /// <summary>
        /// Operação para venda de um produto
        /// </summary>
        /// <param name="command">Ids de Produto, tipo de operação e valor</param>
        [HttpPost("sell")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest, Type = typeof(BadRequestResult))]
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
