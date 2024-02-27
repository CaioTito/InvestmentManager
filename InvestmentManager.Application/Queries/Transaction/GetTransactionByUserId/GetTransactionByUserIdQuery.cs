using InvestmentManager.Application.ViewModels;
using MediatR;

namespace InvestmentManager.Application.Queries
{
    public class GetTransactionByUserIdQuery : IRequest<List<TransactionViewModel>>
    {
        public GetTransactionByUserIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
