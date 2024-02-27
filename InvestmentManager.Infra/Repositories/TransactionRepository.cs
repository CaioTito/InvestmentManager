using InvestmentManager.Domain.Entities;
using InvestmentManager.Domain.Interfaces.Repositories;
using InvestmentManager.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace InvestmentManager.Infra.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly InvestmentManagerDataContext _context;

        public TransactionRepository(InvestmentManagerDataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Transactions transactions)
        {
            await _context.Transactions.AddAsync(transactions);
            await _context.SaveChangesAsync();
        }

        public async Task<Transactions> GetTransactionByIdAsync(Guid id)
        {
            var transactions = await _context.Transactions.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id && p.DeletedAt == null);

            if (transactions == null)
                return null;

            return transactions;
        }

        public async Task<List<Transactions>> GetTransactionByOperationIdAsync(Guid id)
        {
            var transactions = await _context.Transactions.AsNoTracking()
                    .Include(x => x.User)
                    .Include(x => x.Product)
                    .Where(x => x.OperationType.Id == id)
                    .Where(t => t.DeletedAt == null)
                    .Include(x => x.OperationType)
                    .ToListAsync();

            if (transactions == null)
                return null;

            return transactions;
        }

        public async Task<List<Transactions>> GetTransactionByProductIdAsync(Guid id)
        {
            var transactions = await _context.Transactions.AsNoTracking()
                    .Include(x => x.User)
                    .Include(x => x.Product)
                    .Where(x => x.Product.Id == id)
                    .Where(t => t.DeletedAt == null)
                    .Include(x => x.OperationType)
                    .ToListAsync();

            if (transactions == null)
                return null;

            return transactions;
        }

        public async Task<List<Transactions>> GetTransactionByUserId(Guid userId)
        {
            var transactions = await _context.Transactions.AsNoTracking()
                    .Include(x => x.User)
                    .Where(x => x.User.Id == userId)
                    .Include(x => x.Product)
                    .Where(t => t.DeletedAt == null)
                    .Include(x => x.OperationType)
                    .ToListAsync();

            if (transactions == null)
                return null;

            return transactions;
        }

        public async Task<Transactions> GetTransactionRelation(Guid userId, Guid productId, Guid operationId)
        {
            var userProduct = await _context.Transactions
                    .Include(x => x.User)
                    .Include(x => x.Product)
                    .FirstOrDefaultAsync(t => t.User.Id == userId && t.Product.Id == productId && t.OperationType.Id == operationId && t.DeletedAt == null);

            if (userProduct == null)
                return null;

            return userProduct;
        }

        public void Update(Transactions transaction)
        {
            _context.Transactions.Update(transaction);
            _context.SaveChanges();
        }
    }
}
