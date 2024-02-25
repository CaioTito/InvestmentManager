using GestaoInvestimentos.Domain.Entities;

namespace GestaoInvestimentos.Domain.Interfaces.Repositories
{
    public interface IOperationTypeRepository
    {
        Task<OperationType> GetOperationByIdAsync(Guid id);
        Task AddAsync(OperationType category);
        void Update(OperationType category);
    }
}
