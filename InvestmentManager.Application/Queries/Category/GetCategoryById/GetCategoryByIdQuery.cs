using InvestmentManager.Application.ViewModels;
using MediatR;

namespace InvestmentManager.Application.Queries
{
    public class GetCategoryByIdQuery : IRequest<CategoryViewModel>
    {
        public GetCategoryByIdQuery()
        {
            
        }
        public GetCategoryByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
