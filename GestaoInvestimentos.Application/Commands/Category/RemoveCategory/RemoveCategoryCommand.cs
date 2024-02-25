using MediatR;

namespace GestaoInvestimentos.Application.Commands
{
    public class RemoveCategoryCommand : IRequest<Unit>
    {
        public RemoveCategoryCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
