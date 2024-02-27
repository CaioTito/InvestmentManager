using MediatR;

namespace InvestmentManager.Application.Commands
{
    public class PromoteUserCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
