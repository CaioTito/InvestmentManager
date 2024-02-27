using InvestmentManager.Application.ViewModels;
using MediatR;

namespace InvestmentManager.Application.Queries
{
    public class GetProductByIdQuery : IRequest<ProductViewModel>
    {
        public GetProductByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
