using MediatR;

namespace InvestmentManager.Application.Commands
{
    public class RemoveUserCommand : IRequest<Unit>
    {
        public RemoveUserCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
