using InvestmentManager.Application.ViewModels;
using MediatR;

namespace InvestmentManager.Application.Queries.Transaction.GetTransactionById
{
    public class GetTransactionByIdQuery : IRequest<TransactionViewModel>
    {
        public GetTransactionByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
