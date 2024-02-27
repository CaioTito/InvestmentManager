using InvestmentManager.Application.Commands;
using InvestmentManager.Application.Queries;
using InvestmentManager.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InvestmentManager.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retorna todas os produtos de acordo com o digitado na query
        /// </summary>
        /// <param name="getAllProductsQuery">Query de busca</param>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<ProductViewModel>))]
        [Authorize(Roles = "Administrator, Customer")]
        public async Task<ActionResult> GetAll([FromQuery] GetAllProductsQuery getAllProductsQuery)
        {
            var products = await _mediator.Send(getAllProductsQuery);

            return Ok(products);
        }

        /// <summary>
        /// Retorna o produto de acordo com o digitado no id
        /// </summary>
        /// <param name="id">ID do produto</param>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ProductViewModel))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(NotFoundResult))]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> GetProductsById(Guid id)
        {
            var getProductByIdQuery = new GetProductByIdQuery(id);

            var product = await _mediator.Send(getProductByIdQuery);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        /// <summary>
        /// Cria o produto de acordo com os dados enviados
        /// </summary>
        /// <param name="command">Dados de criação do produto</param>
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> CreateProduct([FromBody] CreateProductCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetProductsById), new { id }, command);
        }

        /// <summary>
        /// Atualiza o produto de acordo com os dados enviados
        /// </summary>
        /// <param name="command">Dados de atualização do produto</param>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Deleta o produto de acordo com o id enviados
        /// </summary>
        /// <param name="id">Id do produto</param>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var command = new RemoveProductCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
