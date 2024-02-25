using GestaoInvestimentos.Domain.Entities;
using GestaoInvestimentos.Domain.Interfaces.Repositories;
using MediatR;

namespace GestaoInvestimentos.Application.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductsRepository _productsRepository;
        private readonly ICategoriesRepository _categoriesRepository;

        public CreateProductCommandHandler(IProductsRepository productsRepository, ICategoriesRepository categoriesRepository)
        {
            _productsRepository = productsRepository;
            _categoriesRepository = categoriesRepository;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoriesRepository.GetCategoryByIdAsync(request.CategoryId);

            var product = new Products(
                request.Name,
                category,
                request.Liquidity,
                request.AnnualRate,
                request.MinimumInvestment,
                request.ExpirationDate);

            await _productsRepository.AddAsync(product);

            return product.Id;
        }
    }
}
