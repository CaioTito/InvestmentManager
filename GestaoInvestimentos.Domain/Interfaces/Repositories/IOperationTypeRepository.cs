using InvestmentManager.Domain.Entities;

namespace InvestmentManager.Domain.Interfaces.Repositories
{
    public interface IOperationTypeRepository
    {
        Task<OperationType> GetOperationByIdAsync(Guid id);
        Task<List<OperationType>> GetAllOperationTypes(string query);
        Task AddAsync(OperationType operation);
        void Update(OperationType operation);
    }
}
