using MediatR;

namespace InvestmentManager.Application.Commands
{
    public class RemoveProductCommand : IRequest<Unit>
    {
        public RemoveProductCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
