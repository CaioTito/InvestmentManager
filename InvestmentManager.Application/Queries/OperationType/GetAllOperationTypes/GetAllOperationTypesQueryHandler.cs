using InvestmentManager.Application.ViewModels;
using InvestmentManager.Domain.Interfaces.Repositories;
using MediatR;

namespace InvestmentManager.Application.Queries
{
    public class GetAllOperationTypesQueryHandler : IRequestHandler<GetAllOperationTypesQuery, List<OperationTypesViewModel>>
    {
        private readonly IOperationTypeRepository _operationTypeRepository;

        public GetAllOperationTypesQueryHandler(IOperationTypeRepository operationTypeRepository)
        {
            _operationTypeRepository = operationTypeRepository;
        }

        public async Task<List<OperationTypesViewModel>> Handle(GetAllOperationTypesQuery request, CancellationToken cancellationToken)
        {
            var operationTypes = await _operationTypeRepository.GetAllOperationTypes(request.Query);

            return operationTypes
            .Select(c => new OperationTypesViewModel(c.Id, c.Name))
            .ToList();
        }
    }
}
