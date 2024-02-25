using MediatR;

namespace GestaoInvestimentos.Application.Commands
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
