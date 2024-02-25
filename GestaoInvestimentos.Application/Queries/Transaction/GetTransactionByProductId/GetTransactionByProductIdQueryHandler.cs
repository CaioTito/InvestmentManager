using GestaoInvestimentos.Application.ViewModels;
using GestaoInvestimentos.Domain.Interfaces.Repositories;
using MediatR;

namespace GestaoInvestimentos.Application.Queries
{
    public class GetTransactionByProductIdQueryHandler : IRequestHandler<GetTransactionByProductIdQuery, TransactionViewModel>
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetTransactionByProductIdQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<TransactionViewModel> Handle(GetTransactionByProductIdQuery request, CancellationToken cancellationToken)
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
