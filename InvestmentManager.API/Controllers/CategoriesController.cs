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
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Retorna todas as categorias de acordo com o digitado na query
        /// </summary>
        /// <param name="getAllCategoriesQuery">Query de busca</param>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<CategoryViewModel>))]
        [Authorize(Roles = "Administrator, Customer")]
        public async Task<ActionResult> GetAll([FromQuery]GetAllCategoriesQuery getAllCategoriesQuery)
        {
            var categories = await _mediator.Send(getAllCategoriesQuery);

            return Ok(categories);
        }

        /// <summary>
        /// Retorna a categoria de acordo com o id
        /// </summary>
        /// <param name="id">Id da categoria</param>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(CategoryViewModel))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(NotFoundResult))]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> GetCategoryById(Guid id)
        {
            var getCategoryByIdQuery = new GetCategoryByIdQuery(id);

            var category = await _mediator.Send(getCategoryByIdQuery);

            if (category == null)
                return NotFound();

            return Ok(category);
        }

        /// <summary>
        /// Cria uma categoria
        /// </summary>
        /// <param name="command">Nome da categoria</param>
        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetCategoryById), new { id }, command);
        }

        /// <summary>
        /// Edita uma categoria
        /// </summary>
        /// <param name="command">Id e Nome da categoria</param>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> UpdateCategory([FromBody] UpdateCategoryCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Deleta uma categoria
        /// </summary>
        /// <param name="id">Id da categoria</param>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var command = new RemoveCategoryCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
