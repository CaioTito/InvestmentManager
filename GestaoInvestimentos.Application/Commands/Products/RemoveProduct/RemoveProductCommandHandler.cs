using InvestmentManager.Domain.Interfaces.Repositories;
using MediatR;

namespace InvestmentManager.Application.Commands
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand, Unit>
    {
        private readonly IProductsRepository _productsRepository;

        public RemoveProductCommandHandler(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<Unit> Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productsRepository.GetProductByIdAsync(request.Id);

            product.Delete();
            _productsRepository.Update(product);

            return Unit.Value;
        }
    }
}
