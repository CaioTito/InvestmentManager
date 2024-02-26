using MediatR;

namespace GestaoInvestimentos.Application.Commands
{
    public class PromoteUserCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
