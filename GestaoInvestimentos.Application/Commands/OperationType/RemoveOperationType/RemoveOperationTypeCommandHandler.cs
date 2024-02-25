using GestaoInvestimentos.Domain.Interfaces.Repositories;
using MediatR;

namespace GestaoInvestimentos.Application.Commands
{
    public class RemoveOperationTypeCommandHandler : IRequestHandler<RemoveOperationTypeCommand, Unit>
    {
        private readonly IOperationTypeRepository _operationTypeRepository;

        public RemoveOperationTypeCommandHandler(IOperationTypeRepository operationTypeRepository)
        {
            _operationTypeRepository = operationTypeRepository;
        }

        public async Task<Unit> Handle(RemoveOperationTypeCommand request, CancellationToken cancellationToken)
        {
            var operationType = await _operationTypeRepository.GetOperationByIdAsync(request.Id);

            operationType.Delete();
            _operationTypeRepository.Update(operationType);

            return Unit.Value;
        }
    }
}
