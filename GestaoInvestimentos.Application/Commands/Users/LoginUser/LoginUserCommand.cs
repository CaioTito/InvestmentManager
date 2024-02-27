using MediatR;

namespace InvestmentManager.Application.Commands
{
    public class LoginUserCommand : IRequest<string>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

    }
}
