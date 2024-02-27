using MediatR;

namespace InvestmentManager.Application.Commands
{
    public class UpdateOperationTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
