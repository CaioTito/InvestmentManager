using MediatR;

namespace InvestmentManager.Application.Commands
{
    public class UpdateUserCommand : IRequest<Unit>
    {
        public string Email { get; set; } = string.Empty;
        public int Role { get; set; }
    }
}
