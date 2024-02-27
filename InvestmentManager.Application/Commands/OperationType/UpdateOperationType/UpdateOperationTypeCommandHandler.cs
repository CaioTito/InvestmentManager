using InvestmentManager.Domain.Interfaces.Repositories;
using MediatR;

namespace InvestmentManager.Application.Commands
{
    public class UpdateOperationTypeCommandHandler : IRequestHandler<UpdateOperationTypeCommand, Unit>
    {
        private readonly IOperationTypeRepository _operationTypeRepository;

        public UpdateOperationTypeCommandHandler(IOperationTypeRepository operationTypeRepository)
        {
            _operationTypeRepository = operationTypeRepository;
        }

        public async Task<Unit> Handle(UpdateOperationTypeCommand request, CancellationToken cancellationToken)
        {
            var operationType = await _operationTypeRepository.GetOperationByIdAsync(request.Id);

            operationType.Update(request.Name);
            _operationTypeRepository.Update(operationType);

            return Unit.Value;
        }
    }
}
