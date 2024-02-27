using MediatR;

namespace InvestmentManager.Application.Commands
{
    public class CreateUserCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public string Cpf { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public decimal Balance { get; set; }
    }
}
