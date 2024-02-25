using GestaoInvestimentos.Domain.Entities;

namespace GestaoInvestimentos.Domain.Interfaces.Repositories
{
    public interface ITransactionRepository
    {
        Task<Transactions> GetTransactionByIdAsync(Guid id);
        Task<Transactions> GetTransactionByUserIdAsync(Guid id);
        Task<Transactions> GetTransactionByOperationIdAsync(Guid id);
        Task<Transactions> GetTransactionByProductIdAsync(Guid id);
        Task AddAsync(Transactions transactions, Users user, Products product);
    }
}
