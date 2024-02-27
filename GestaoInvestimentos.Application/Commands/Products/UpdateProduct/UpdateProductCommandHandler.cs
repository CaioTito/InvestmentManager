using InvestmentManager.Domain.Interfaces.Repositories;
using MediatR;

namespace InvestmentManager.Application.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductsRepository _productsRepository;
        private readonly ICategoriesRepository _categoriesRepository;

        public UpdateProductCommandHandler(IProductsRepository productsRepository, ICategoriesRepository categoriesRepository)
        {
            _productsRepository = productsRepository;
            _categoriesRepository = categoriesRepository;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productsRepository.GetProductByIdAsync(request.Id);
            var category = await _categoriesRepository.GetCategoryByIdAsync(request.CategoryId);

            product.Update(request.Name, category, request.Liquidity, request.AnnualRate, request.MinimumInvestment, request.ExpirationDate);
            _productsRepository.Update(product);

            return Unit.Value;
        }
    }
}
