﻿using InvestmentManager.Domain.Entities;
using InvestmentManager.Domain.Interfaces.Repositories;
using MediatR;

namespace InvestmentManager.Application.Commands
{
    public class CreateTransactionCommandHandler : IRequestHandler<CreateTransactionCommand, Guid>
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IUsersRepository _userRepository;
        private readonly IProductsRepository _productRepository;
        private readonly IUserProductsRepository _userProductsRepository;
        private readonly IOperationTypeRepository _operationTypeRepository;

        public CreateTransactionCommandHandler(ITransactionRepository transactionRepository, IUsersRepository userRepository, IProductsRepository productRepository, IUserProductsRepository userProductsRepository, IOperationTypeRepository operationTypeRepository)
        {
            _transactionRepository = transactionRepository;
            _userRepository = userRepository;
            _productRepository = productRepository;
            _userProductsRepository = userProductsRepository;
            _operationTypeRepository = operationTypeRepository;
        }

        public async Task<Guid> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetUserByIdAsync(request.UserId);
                var product = await _productRepository.GetProductByIdAsync(request.ProductId);
                var operationType = await _operationTypeRepository.GetOperationByIdAsync(request.OperationId);
                var quantity = (request.Value / product.MinimumInvestment);

                if (user.Balance < request.Value)
                    throw new Exception("Your balance is insufficient for this quantity");
                user.UpdateBalanceBuy(request.Value);

                var transaction = new Transactions(quantity, request.Value, operationType, product, user);
                var userProduct = new UserProducts(quantity, request.Value, user, product);

                var userProductRelation = await _userProductsRepository.GetUserProducts(request.UserId, request.ProductId);
                if (userProductRelation != null)
                {
                    userProductRelation.UpdateQuantityBuy(quantity, request.Value);
                    _userProductsRepository.Update(userProductRelation);

                    var transactionRelation = await _transactionRepository.GetTransactionRelation(request.UserId, request.ProductId, request.OperationId);
                    if (transactionRelation != null)
                    {
                        transactionRelation.UpdateQuantityBuy(quantity, request.Value);
                        _transactionRepository.Update(transactionRelation);

                        return transaction.Id;
                    }

                    return transaction.Id;
                }
                var transactionRelations = await _transactionRepository.GetTransactionRelation(request.UserId, request.ProductId, request.OperationId);
                if (transactionRelations != null)
                {
                    transactionRelations.UpdateQuantityBuy(quantity, request.Value);
                    _transactionRepository.Update(transactionRelations
                        );

                    await _userProductsRepository.AddAsync(userProduct);

                    return transaction.Id;
                }                

                await _transactionRepository.AddAsync(transaction);
                await _userProductsRepository.AddAsync(userProduct);

                return transaction.Id;
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}