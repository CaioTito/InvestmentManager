using InvestmentManager.Application.ViewModels;
using MediatR;

namespace InvestmentManager.Application.Queries
{
    public class GetTransactionByOperationIdQuery : IRequest<List<TransactionViewModel>>
    {
        public GetTransactionByOperationIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
