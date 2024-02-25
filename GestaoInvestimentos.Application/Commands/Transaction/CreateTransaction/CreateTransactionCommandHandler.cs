using GestaoInvestimentos.Domain.Entities;
using GestaoInvestimentos.Domain.Interfaces.Repositories;
using MediatR;

namespace GestaoInvestimentos.Application.Commands
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Guid>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUsersRepository _userRepository;
        private readonly IProductsRepository _productsRepository;

        public CreateTransactionCommandHandler(ITransactionRepository transactionRepository, IUsersRepository userRepository, IProductsRepository productsRepository)
        {
            _transactionRepository = transactionRepository;
            _userRepository = userRepository;
            _productsRepository = productsRepository;
        }

        public async Task<Guid> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(request.UserId);
                var product = await _productsRepository.GetProductByIdAsync(request.ProductId);

                if (user.Balance < (request.Quantity * product.MinimumInvestment))
                    throw new Exception("O seu saldo é insuficiente para essa quantidade");

               user.UpdateBalance((request.Quantity * product.MinimumInvestment));

                var transaction = new Transactions(request.OperationId, request.ProductId, 
                    request.UserId);

                await _transactionRepository.AddAsync(transaction, user, product);

                return transaction.Id;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
