using MediatR;

namespace InvestmentManager.Application.Commands
{
    public class CreateOperationTypeCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
    }
}
