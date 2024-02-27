using InvestmentManager.Application.ViewModels;
using MediatR;

namespace InvestmentManager.Application.Queries
{
    public class GetAllProductsQuery : IRequest<List<ProductViewModel>>
    {
        public string Query { get; set; } = string.Empty;
    }
}
