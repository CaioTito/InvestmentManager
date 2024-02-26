using GestaoInvestimentos.Application.ViewModels;
using MediatR;

namespace GestaoInvestimentos.Application.Queries
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
