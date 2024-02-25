using GestaoInvestimentos.Domain.Entities;
using GestaoInvestimentos.Domain.Interfaces.Repositories;

namespace GestaoInvestimentos.Infra.Repositories
{
    public class OperationTypeRepository : IOperationTypeRepository
    {
        public Task AddAsync(OperationType category)
        {
            throw new NotImplementedException();
        }

        public Task<OperationType> GetOperationByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(OperationType category)
        {
            throw new NotImplementedException();
        }
    }
}
