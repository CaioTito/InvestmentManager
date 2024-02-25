using MediatR;

namespace GestaoInvestimentos.Application.Commands
{
    public class UpdateOperationTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
