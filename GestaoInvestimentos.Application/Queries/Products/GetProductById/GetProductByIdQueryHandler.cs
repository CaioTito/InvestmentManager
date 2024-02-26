using GestaoInvestimentos.Application.ViewModels;
using GestaoInvestimentos.Domain.Interfaces.Repositories;
using MediatR;

namespace GestaoInvestimentos.Application.Queries
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductViewModel>
    {
        private readonly IProductsRepository _productRepository;

        public GetProductByIdQueryHandler(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductViewModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsync(request.Id);

            if (product == null)
                return null;

            return new ProductViewModel(
                product.Id,
                product.Name,
                product.Category.Id,
                product.Liquidity,
                product.AnnualRate,
                product.MinimumInvestment,
                product.ExpirationDate);
        }
    }
}
