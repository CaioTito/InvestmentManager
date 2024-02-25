using GestaoInvestimentos.Application.ViewModels;
using GestaoInvestimentos.Domain.Interfaces.Repositories;
using MediatR;

namespace GestaoInvestimentos.Application.Queries
{
    public class GetTransactionByOperationIdQueryHandler : IRequestHandler<GetTransactionByOperationIdQuery, TransactionViewModel>
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetTransactionByOperationIdQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<TransactionViewModel> Handle(GetTransactionByOperationIdQuery request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetTransactionByOperationIdAsync(request.Id);

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
