using GestaoInvestimentos.Application.Commands;
using GestaoInvestimentos.Application.Queries;
using GestaoInvestimentos.Application.Queries.Users.GetAllUsers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestaoInvestimentos.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> GetAll([FromQuery] GetAllUsersQuery getAllUsersQuery)
        {
            var users = await _mediator.Send(getAllUsersQuery);

            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> GetUserById(Guid id)
        {
            var getUserByIdQuery = new GetUserByIdQuery(id);

            var user = await _mediator.Send(getUserByIdQuery);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetUserById), new { id }, command);
        }

        [HttpPost("login")]
        [AllowAnonymous]

        public async Task<IActionResult> Login([FromBody] LoginUserCommand login)
        {
            return Ok(new { token = await _mediator.Send(login) });
        }
        [HttpPost("promote")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> PromoteAdmin([FromBody] PromoteUserCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpPut]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> UpdateUser([FromBody] UpdateUserCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var command = new RemoveUserCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
