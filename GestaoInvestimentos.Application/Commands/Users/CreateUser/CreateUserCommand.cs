using MediatR;

namespace GestaoInvestimentos.Application.Commands
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Role { get; set; } = 2;
        public decimal Balance { get; set; }
    }
}
