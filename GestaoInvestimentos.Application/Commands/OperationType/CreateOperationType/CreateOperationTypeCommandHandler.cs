using GestaoInvestimentos.Domain.Entities;
using GestaoInvestimentos.Domain.Interfaces.Repositories;
using MediatR;

namespace GestaoInvestimentos.Application.Commands
{
    public class CreateOperationTypeCommandHandler : IRequestHandler<CreateOperationTypeCommand, Guid>
    {
        private readonly IOperationTypeRepository _operationTypeRepository;

        public CreateOperationTypeCommandHandler(IOperationTypeRepository operationTypeRepository)
        {
            _operationTypeRepository = operationTypeRepository;
        }

        public async Task<Guid> Handle(CreateOperationTypeCommand request, CancellationToken cancellationToken)
        {
            var operationType = new OperationType(request.Name);

            await _operationTypeRepository.AddAsync(operationType);

            return operationType.Id;
        }
    }
}
