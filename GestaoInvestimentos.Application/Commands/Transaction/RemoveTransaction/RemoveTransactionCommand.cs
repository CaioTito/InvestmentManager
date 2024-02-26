using MediatR;

namespace GestaoInvestimentos.Application.Commands
{
    public class RemoveTransactionCommand : IRequest<Guid>
    {
        public decimal Value { get; set; }
        public Guid OperationId { get; set; }
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
    }
}
