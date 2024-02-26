using GestaoInvestimentos.Application.ViewModels;
using MediatR;

namespace GestaoInvestimentos.Application.Queries.Category.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<List<CategoryViewModel>>
    {
        public string Query { get; set; } = string.Empty;
    }
}
