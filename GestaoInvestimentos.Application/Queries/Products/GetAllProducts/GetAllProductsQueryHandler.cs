using GestaoInvestimentos.Application.ViewModels;
using GestaoInvestimentos.Domain.Interfaces.Repositories;
using MediatR;

namespace GestaoInvestimentos.Application.Queries.Products.GetAllProducts
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductViewModel>>
    {
        private readonly IProductsRepository _productsRepository;

        public GetAllProductsQueryHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<List<ProductViewModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var products = await _productsRepository.GetAllProducts(request.Query);

            return products
            .Select(c => new ProductViewModel(c.Id, c.Name, c.Category.Id, c.Liquidity, c.AnnualRate, c.MinimumInvestment, c.ExpirationDate))
            .ToList();
        }
    }
}
