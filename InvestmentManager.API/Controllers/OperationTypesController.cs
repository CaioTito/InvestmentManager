using InvestmentManager.Application.Commands;
using InvestmentManager.Application.Queries;
using InvestmentManager.Application.Queries.Category.GetAllCategories;
using InvestmentManager.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InvestmentManager.API.Controllers
{
    [ApiController]
    [Route("api/operationTypes")]
    public class OperationTypesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OperationTypesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retorna todas os tipos de operação de acordo com o digitado na query
        /// </summary>
        /// <param name="getAllOperationTypesQuery">Query de busca</param>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<OperationTypesViewModel>))]
        [Authorize(Roles = "Administrator, Customer")]
        public async Task<ActionResult> GetAll([FromQuery] GetAllOperationTypesQuery getAllOperationTypesQuery)
        {
            var operationTypes = await _mediator.Send(getAllOperationTypesQuery);

            return Ok(operationTypes);
        }

        /// <summary>
        /// Retorna o tipo de operação de acordo com o digitado no id
        /// </summary>
        /// <param name="id">Id do tipo de operação</param>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(OperationTypesViewModel))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(NotFoundResult))]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> GetOperationById(Guid id)
        {
            var getOperationByIdQuery = new GetOperationTypeByIdQuery(id);

            var operationType = await _mediator.Send(getOperationByIdQuery);

            if (operationType == null)
                return NotFound();

            return Ok(operationType);
        }

        /// <summary>
        /// Cria um tipo de operação
        /// </summary>
        /// <param name="command">Nome do tipo de operação</param>
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> CreateOperation([FromBody] CreateOperationTypeCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetOperationById), new { id }, command);
        }

        /// <summary>
        /// Atualiza um tipo de operação
        /// </summary>
        /// <param name="command">Nome e Id do tipo de operação</param>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> UpdateOperation([FromBody] UpdateOperationTypeCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Deleta um tipo de operação
        /// </summary>
        /// <param name="id">Id do tipo de operação</param>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteOperation(Guid id)
        {
            var command = new RemoveOperationTypeCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
