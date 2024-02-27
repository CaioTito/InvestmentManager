using InvestmentManager.Application.ViewModels;
using MediatR;

namespace InvestmentManager.Application.Queries
{
    public class GetTransactionByProductIdQuery : IRequest<List<TransactionViewModel>>
    {
        public GetTransactionByProductIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
