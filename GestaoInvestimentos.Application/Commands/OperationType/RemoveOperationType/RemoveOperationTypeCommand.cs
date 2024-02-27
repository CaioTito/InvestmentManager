using MediatR;

namespace InvestmentManager.Application.Commands
{
    public class RemoveOperationTypeCommand : IRequest<Unit>
    {
        public RemoveOperationTypeCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
