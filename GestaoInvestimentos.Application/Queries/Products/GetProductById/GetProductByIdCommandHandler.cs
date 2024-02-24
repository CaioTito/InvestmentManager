using GestaoInvestimentos.Application.ViewModels;
using GestaoInvestimentos.Domain.Interfaces.Repositories;
using MediatR;

namespace GestaoInvestimentos.Application.Queries
{
    public class GetProductByIdCommandHandler : IRequestHandler<GetProductByIdCommand, ProductViewModel>
    {
        private readonly IProductsRepository _productRepository;

        public GetProductByIdCommandHandler(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductViewModel> Handle(GetProductByIdCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductByIdAsync(request.Id);

            if (product == null)
                return null;

            return new ProductViewModel(
                product.Id,
                product.Name,
                product.Category,
                product.Liquidity,
                product.AnnualRate,
                product.MinimumInvestment,
                product.ExpirationDate);
        }
    }
}
