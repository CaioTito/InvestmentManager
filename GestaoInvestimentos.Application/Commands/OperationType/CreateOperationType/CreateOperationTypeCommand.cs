using MediatR;

namespace GestaoInvestimentos.Application.Commands
{
    public class CreateOperationTypeCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
    }
}
