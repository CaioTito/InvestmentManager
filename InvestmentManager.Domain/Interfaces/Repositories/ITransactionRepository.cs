using InvestmentManager.Domain.Entities;

namespace InvestmentManager.Domain.Interfaces.Repositories
{
    public interface ITransactionRepository
    {
        Task<Transactions> GetTransactionByIdAsync(Guid id);
        Task<List<Transactions>> GetTransactionByUserId(Guid userId);
        Task<List<Transactions>> GetTransactionByOperationIdAsync(Guid id);
        Task<List<Transactions>> GetTransactionByProductIdAsync(Guid id);
        Task<Transactions> GetTransactionRelation(Guid userId, Guid productId, Guid operationId);
        void Update(Transactions transaction);
        Task AddAsync(Transactions transactions);
    }
}
