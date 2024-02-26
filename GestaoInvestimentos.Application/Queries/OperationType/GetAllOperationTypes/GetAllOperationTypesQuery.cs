using GestaoInvestimentos.Application.ViewModels;
using MediatR;

namespace GestaoInvestimentos.Application.Queries
{
    public class GetAllOperationTypesQuery : IRequest<List<OperationTypesViewModel>>
    {
        public string Query { get; set; } = string.Empty;
    }
}
