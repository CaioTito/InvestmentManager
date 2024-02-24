using GestaoInvestimentos.Domain.Entities;
using GestaoInvestimentos.Domain.Interfaces.Repositories;
using MediatR;

namespace GestaoInvestimentos.Application.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductsRepository _productsRepository;

        public CreateProductCommandHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Products(
                request.Name,
                request.Category,
                request.Liquidity,
                request.AnnualRate,
                request.MinimumInvestment,
                request.ExpirationDate);

            await _productsRepository.AddAsync(product);

            return product.Id;
        }
    }
}
