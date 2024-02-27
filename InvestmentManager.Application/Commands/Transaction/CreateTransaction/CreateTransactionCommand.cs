using InvestmentManager.Domain.Entities;
using MediatR;

namespace InvestmentManager.Application.Commands
{
    public class CreateTransactionCommand : IRequest<Guid>
    {
        public decimal Value { get; set; }
        public Guid OperationId { get; set; }
        public Guid ProductId { get; set; }
    }
}
