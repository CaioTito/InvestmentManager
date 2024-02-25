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

        public async Task AddAsync(Transactions transactions, Users user, Products product)
        {
            user.Products.Add(product);
            _context.SaveChanges();

            await _context.Transactions.AddAsync(transactions);
            await _context.SaveChangesAsync();
        }

        public async Task<Transactions> GetTransactionByIdAsync(Guid id)
        {
            var transactions = await _context.Transactions.FirstOrDefaultAsync(p => p.Id == id);

            if (transactions == null)
                return null;

            if (transactions.DeletedAt != null)
                return null;

            return transactions;
        }

        public async Task<Transactions> GetTransactionByOperationIdAsync(Guid id)
        {
            var transactions = await _context.Transactions.FirstOrDefaultAsync(p => p.OperationId == id);

            if (transactions == null)
                return null;

            if (transactions.DeletedAt != null)
                return null;

            return transactions;
        }

        public async Task<Transactions> GetTransactionByProductIdAsync(Guid id)
        {
            var transactions = await _context.Transactions.FirstOrDefaultAsync(p => p.ProductId == id);

            if (transactions == null)
                return null;

            if (transactions.DeletedAt != null)
                return null;

            return transactions;
        }

        public async Task<Transactions> GetTransactionByUserIdAsync(Guid id)
        {
            var transactions = await _context.Transactions.FirstOrDefaultAsync(p => p.UserId == id);

            if (transactions == null)
                return null;

            if (transactions.DeletedAt != null)
                return null;

            return transactions;
        }
    }
}
