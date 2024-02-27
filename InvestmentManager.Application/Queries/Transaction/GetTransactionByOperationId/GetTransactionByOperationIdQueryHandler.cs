using InvestmentManager.Application.ViewModels;
using InvestmentManager.Domain.Interfaces.Repositories;
using MediatR;

namespace InvestmentManager.Application.Queries
{
    public class GetTransactionByOperationIdQueryHandler : IRequestHandler<GetTransactionByOperationIdQuery, List<TransactionViewModel>>
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetTransactionByOperationIdQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<List<TransactionViewModel>> Handle(GetTransactionByOperationIdQuery request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetTransactionByOperationIdAsync(request.Id);

            if (transaction == null)
                return null;

            var transactionList = new List<TransactionViewModel>();

            foreach (var t in transaction)
            {
                var transactionViewModel = new TransactionViewModel(
                t.Id,
                t.Product.Name,
                t.Quantity,
                t.OperationType.Name,
                t.User.Name);

                transactionList.Add(transactionViewModel);
            }

            return transactionList;
        }
    }
}
