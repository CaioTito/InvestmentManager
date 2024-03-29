﻿using InvestmentManager.Application.ViewModels;
using InvestmentManager.Domain.Interfaces.Repositories;
using MediatR;

namespace InvestmentManager.Application.Queries
{
    public class GetOperationTypeByIdQueryHandler : IRequestHandler<GetOperationTypeByIdQuery, OperationTypesViewModel>
    {
        private readonly IOperationTypeRepository _operationTypeRepository;

        public GetOperationTypeByIdQueryHandler(IOperationTypeRepository operationTypeRepository)
        {
            _operationTypeRepository = operationTypeRepository;
        }

        public async Task<OperationTypesViewModel> Handle(GetOperationTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var operationType = await _operationTypeRepository.GetOperationByIdAsync(request.Id);

            if (operationType == null)
                return null;

            return new OperationTypesViewModel(operationType.Id, operationType.Name);
        }
    }
}
