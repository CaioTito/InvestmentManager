using GestaoInvestimentos.Application.ViewModels;
using GestaoInvestimentos.Domain.Interfaces.Repositories;
using MediatR;

namespace GestaoInvestimentos.Application.Queries
{
    public class GetTransactionByUserIdQueryHandler : IRequestHandler<GetTransactionByUserIdQuery, TransactionViewModel>
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetTransactionByUserIdQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<TransactionViewModel> Handle(GetTransactionByUserIdQuery request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetTransactionByProductIdAsync(request.Id);

            if (transaction == null)
                return null;

            return new TransactionViewModel(
                transaction.Id,
                transaction.OperationId,
                transaction.ProductId,
                transaction.UserId,
                transaction.CreatedAt);
        }
    }
}
