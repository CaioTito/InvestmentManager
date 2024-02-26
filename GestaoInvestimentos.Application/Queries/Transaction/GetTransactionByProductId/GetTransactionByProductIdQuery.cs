using GestaoInvestimentos.Application.ViewModels;
using MediatR;

namespace GestaoInvestimentos.Application.Queries
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
