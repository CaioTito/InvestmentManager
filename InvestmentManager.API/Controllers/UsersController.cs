using InvestmentManager.Application.Commands;
using InvestmentManager.Application.Queries;
using InvestmentManager.Application.Queries.Users.GetAllUsers;
using InvestmentManager.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InvestmentManager.API.Controllers
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

        /// <summary>
        /// Retorna todas os usuario de acordo com o digitado na query
        /// </summary>
        /// <param name="getAllUsersQuery">Query de busca</param>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(List<UserViewModel>))]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> GetAll([FromQuery] GetAllUsersQuery getAllUsersQuery)
        {
            var users = await _mediator.Send(getAllUsersQuery);

            return Ok(users);
        }

        /// <summary>
        /// Retorna o usuario de acordo com o digitado id
        /// </summary>
        /// <param name="id">Id do Usuario</param>
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(UserViewModel))]
        [ProducesResponseType((int)HttpStatusCode.NotFound, Type = typeof(NotFoundResult))]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> GetUserById(Guid id)
        {
            var getUserByIdQuery = new GetUserByIdQuery(id);

            var user = await _mediator.Send(getUserByIdQuery);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        /// <summary>
        /// Cria um usuário
        /// </summary>
        /// <param name="command">Dados de cadastro</param>
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetUserById), new { id }, command);
        }

        /// <summary>
        /// Realiza o login e te devolve um token
        /// </summary>
        /// <param name="login">Email e senha</param>
        [HttpPost("login")]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(string))]
        [AllowAnonymous]

        public async Task<IActionResult> Login([FromBody] LoginUserCommand login)
        {
            return Ok(new { token = await _mediator.Send(login) });
        }

        /// <summary>
        /// Realiza a atualização do usuário
        /// </summary>
        /// <param name="command">Email e role</param>
        [HttpPut]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [Authorize(Roles = "Administrator, Customer")]
        public async Task<ActionResult> UpdateUser([FromBody] UpdateUserCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Deleta o usuário
        /// </summary>
        /// <param name="id">Id do usuario</param>
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var command = new RemoveUserCommand(id);

            await _mediator.Send(command);

            return NoContent();
        }
    }
}
