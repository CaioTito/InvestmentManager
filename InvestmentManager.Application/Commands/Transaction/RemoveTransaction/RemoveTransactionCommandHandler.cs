using InvestmentManager.Domain.Entities;
using InvestmentManager.Domain.Interfaces.Repositories;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace InvestmentManager.Application.Commands
{
    public class RemoveTransactionCommandHandler : IRequestHandler<RemoveTransactionCommand, Guid>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUsersRepository _userRepository;
        private readonly IProductsRepository _productRepository;
        private readonly IUserProductsRepository _userProductsRepository;
        private readonly IOperationTypeRepository _operationTypeRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RemoveTransactionCommandHandler(ITransactionRepository transactionRepository, IUsersRepository userRepository, IProductsRepository productRepository, IUserProductsRepository userProductsRepository, IOperationTypeRepository operationTypeRepository, IHttpContextAccessor httpContextAccessor)
        {
            _transactionRepository = transactionRepository;
            _userRepository = userRepository;
            _productRepository = productRepository;
            _userProductsRepository = userProductsRepository;
            _operationTypeRepository = operationTypeRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Guid> Handle(RemoveTransactionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var httpContext = _httpContextAccessor.HttpContext;
                var userIdClaim = httpContext.User.Claims.FirstOrDefault(c => c.Type == "UserId");
                if (userIdClaim != null)
                {
                    Guid.TryParse(userIdClaim.Value, out var userId);
                    var user = await _userRepository.GetUserByIdAsync(userId);
                    var product = await _productRepository.GetProductByIdAsync(request.ProductId);
                    var operationType = await _operationTypeRepository.GetOperationByIdAsync(request.OperationId);

                    var quantity = (request.Value / product.MinimumInvestment);

                    var transaction = new Transactions(quantity, request.Value, operationType, product, user);
                    var userProduct = new UserProducts(quantity, request.Value, user, product);

                    var userProductRelation = await _userProductsRepository.GetUserProducts(userId, request.ProductId);

                    if (userProductRelation != null)
                    {
                        if (userProductRelation.Quantity < 0 || userProductRelation.Quantity < quantity)
                            throw new Exception("You do not have this quantity of this product");

                        user.UpdateBalanceSell(request.Value);

                        userProductRelation.UpdateQuantitySell(quantity, request.Value);
                        if (userProductRelation.Quantity == 0)
                            userProductRelation.Delete();
                        _userProductsRepository.Update(userProductRelation);
                        _userRepository.Update(user);

                        var transactionRelation = await _transactionRepository.GetTransactionRelation(userId, request.ProductId, request.OperationId);

                        if (transactionRelation != null)
                        {
                            transactionRelation.UpdateQuantitySell(quantity, request.Value);
                            if (transactionRelation.Quantity == 0)
                                transactionRelation.Delete();
                            _transactionRepository.Update(transactionRelation);

                            return transaction.Id;
                        }

                        await _transactionRepository.AddAsync(transaction);

                        return transaction.Id;
                    }
                    else
                        throw new Exception("You do not have this product");
                }
                throw new Exception("Error in UserId identification");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
