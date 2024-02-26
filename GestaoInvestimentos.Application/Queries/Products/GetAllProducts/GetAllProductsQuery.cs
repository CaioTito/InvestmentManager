using GestaoInvestimentos.Application.ViewModels;
using MediatR;

namespace GestaoInvestimentos.Application.Queries
{
    public class GetAllProductsQuery : IRequest<List<ProductViewModel>>
    {
        public string Query { get; set; } = string.Empty;
    }
}
