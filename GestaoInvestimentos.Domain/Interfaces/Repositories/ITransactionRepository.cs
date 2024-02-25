using GestaoInvestimentos.Domain.Entities;

namespace GestaoInvestimentos.Domain.Interfaces.Repositories
{
    public interface ITransactionRepository
    {
        Task<Transactions> GetTransactionByIdAsync(Guid id);
        Task<Transactions> GetTransactionByUserIdAsync(Guid id);
        Task<Transactions> GetTransactionByOperationIdAsync(Guid id);
        Task<Transactions> GetTransactionByProductIdAsync(Guid id);
        Task<Transactions> GetTransaction(Guid userId, Guid productId, Guid operationId);
        void Update(Transactions transaction);
        Task AddAsync(Transactions transactions);
    }
}
