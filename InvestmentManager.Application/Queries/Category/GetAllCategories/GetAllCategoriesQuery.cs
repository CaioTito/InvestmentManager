using InvestmentManager.Application.ViewModels;
using MediatR;

namespace InvestmentManager.Application.Queries.Category.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<List<CategoryViewModel>>
    {
        public string Query { get; set; } = string.Empty;
    }
}
