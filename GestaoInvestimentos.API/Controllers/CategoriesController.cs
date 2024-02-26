using GestaoInvestimentos.Application.Commands;
using GestaoInvestimentos.Application.Queries;
using GestaoInvestimentos.Application.Queries.Category.GetAllCategories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestaoInvestimentos.API.Controllers
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

        [HttpGet]
        [Authorize(Roles = "Administrator, Customer")]
        public async Task<ActionResult> GetAll([FromQuery]GetAllCategoriesQuery getAllCategoriesQuery)
        {
            var categories = await _mediator.Send(getAllCategoriesQuery);

            return Ok(categories);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> GetCategoryById(Guid id)
        {
            var getCategoryByIdQuery = new GetCategoryByIdQuery(id);

            var category = await _mediator.Send(getCategoryByIdQuery);

            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetCategoryById), new { id }, command);
        }

        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> UpdateCategory([FromBody] UpdateCategoryCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            var command = new RemoveCategoryCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
