using GestaoInvestimentos.Application.Commands;
using GestaoInvestimentos.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestaoInvestimentos.API.Controllers
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

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> GetOperationById(Guid id)
        {
            var getOperationByIdQuery = new GetOperationTypeByIdQuery(id);

            var operationType = await _mediator.Send(getOperationByIdQuery);

            if (operationType == null)
                return NotFound();

            return Ok(operationType);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> CreateOperation([FromBody] CreateOperationTypeCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetOperationById), new { id }, command);
        }

        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> UpdateOperation([FromBody] UpdateOperationTypeCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteOperation(Guid id)
        {
            var command = new RemoveOperationTypeCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
