using GestaoInvestimentos.Application.ViewModels;
using MediatR;

namespace GestaoInvestimentos.Application.Queries
{
    public class GetTransactionByUserIdQuery : IRequest<TransactionViewModel>
    {
        public GetTransactionByUserIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
