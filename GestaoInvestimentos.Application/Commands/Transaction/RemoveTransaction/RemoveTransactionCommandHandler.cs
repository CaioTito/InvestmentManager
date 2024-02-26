using GestaoInvestimentos.Domain.Entities;
using GestaoInvestimentos.Domain.Interfaces.Repositories;
using MediatR;

namespace GestaoInvestimentos.Application.Commands
{
    public class RemoveTransactionCommandHandler : IRequestHandler<RemoveTransactionCommand, Guid>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUsersRepository _userRepository;
        private readonly IProductsRepository _productRepository;
        private readonly IUserProductsRepository _userProductsRepository;
        private readonly IOperationTypeRepository _operationTypeRepository;

        public RemoveTransactionCommandHandler(ITransactionRepository transactionRepository, IUsersRepository userRepository, IProductsRepository productRepository, IUserProductsRepository userProductsRepository, IOperationTypeRepository operationTypeRepository)
        {
            _transactionRepository = transactionRepository;
            _userRepository = userRepository;
            _productRepository = productRepository;
            _userProductsRepository = userProductsRepository;
            _operationTypeRepository = operationTypeRepository;
        }

        public async Task<Guid> Handle(RemoveTransactionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(request.UserId);
                var product = await _productRepository.GetProductByIdAsync(request.ProductId);
                var operationType = await _operationTypeRepository.GetOperationByIdAsync(request.OperationId);

                var quantity = (request.Value / product.MinimumInvestment);

                var transaction = new Transactions(quantity, request.Value, request.OperationId, request.ProductId, request.UserId, operationType, product, user);
                var userProduct = new UserProducts(quantity, request.Value, request.ProductId, request.UserId, user, product);

                var userProductRelation = await _userProductsRepository.GetUserProducts(request.UserId, request.ProductId);

                if (userProductRelation != null)
                {
                    if (userProductRelation.Quantity < 0)
                        throw new Exception("Você está tentando vender uma quantidade maior do que você tem.");

                    user.UpdateBalanceSell(request.Value);

                    userProductRelation.UpdateQuantitySell(quantity, request.Value);
                    if (userProductRelation.Quantity == 0)
                        userProductRelation.Delete();
                    _userProductsRepository.Update(userProductRelation);

                    var transactionRelation = await _transactionRepository.GetTransactionRelation(request.UserId, request.ProductId, request.OperationId);

                    if (transactionRelation != null)
                    {
                        if (transactionRelation.Quantity < 0)
                            throw new Exception("Você está tentando vender uma quantidade maior do que você tem.");

                        transactionRelation.UpdateQuantitySell(quantity, request.Value);
                        if (transactionRelation.Quantity == 0)
                            transactionRelation.Delete();
                        _transactionRepository.Update(transactionRelation);

                        return transaction.Id;
                    }

                }

                await _transactionRepository.AddAsync(transaction);

                return transaction.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
