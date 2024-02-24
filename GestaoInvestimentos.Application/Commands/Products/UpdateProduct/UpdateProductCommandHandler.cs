using GestaoInvestimentos.Domain.Interfaces.Repositories;
using MediatR;

namespace GestaoInvestimentos.Application.Commands
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IProductsRepository _productsRepository;

        public UpdateProductCommandHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productsRepository.GetProductByIdAsync(request.Id);

            product.Update(request.Name, request.Category, request.Liquidity, request.AnnualRate, request.MinimumInvestment, request.ExpirationDate);
            _productsRepository.Update(product);

            return Unit.Value;
        }
    }
}
