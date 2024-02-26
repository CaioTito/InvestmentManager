using GestaoInvestimentos.Application.ViewModels;
using GestaoInvestimentos.Domain.Interfaces.Repositories;
using MediatR;

namespace GestaoInvestimentos.Application.Queries
{
    public class GetTransactionByProductIdQueryHandler : IRequestHandler<GetTransactionByProductIdQuery, List<TransactionViewModel>>
    {
        private readonly ITransactionRepository _transactionRepository;

        public GetTransactionByProductIdQueryHandler(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public async Task<List<TransactionViewModel>> Handle(GetTransactionByProductIdQuery request, CancellationToken cancellationToken)
        {
            var transaction = await _transactionRepository.GetTransactionByProductIdAsync(request.Id);

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
