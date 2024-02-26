using GestaoInvestimentos.Domain.Entities;
using GestaoInvestimentos.Domain.Interfaces.Repositories;
using GestaoInvestimentos.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoInvestimentos.Infra.Repositories
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
                    .Where(p => p.OperationId == id)
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
                    .Where(p => p.ProductId == id)
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
                    .Where(p => p.UserId == userId)
                    .Where(t => t.DeletedAt == null)
                    .Include(x => x.OperationType)
                    .ToListAsync();

            if (transactions == null)
                return null;

            return transactions;
        }

        public async Task<Transactions> GetTransactionRelation(Guid userId, Guid productId, Guid operationId)
        {
            var userProduct = await _context.Transactions.AsNoTracking().FirstOrDefaultAsync(t => t.UserId == userId && t.ProductId == productId && t.OperationId == operationId && t.DeletedAt == null);

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
