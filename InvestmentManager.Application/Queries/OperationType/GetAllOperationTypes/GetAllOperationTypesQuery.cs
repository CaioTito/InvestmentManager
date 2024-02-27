using InvestmentManager.Application.ViewModels;
using MediatR;

namespace InvestmentManager.Application.Queries
{
    public class GetAllOperationTypesQuery : IRequest<List<OperationTypesViewModel>>
    {
        public string Query { get; set; } = string.Empty;
    }
}
