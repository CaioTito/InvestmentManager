using GestaoInvestimentos.Domain.Entities;
using GestaoInvestimentos.Domain.Interfaces.Repositories;
using GestaoInvestimentos.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoInvestimentos.Infra.Repositories
{
    public class UserProductsRepository : IUserProductsRepository
    {
        private readonly InvestmentManagerDataContext _context;

        public UserProductsRepository(InvestmentManagerDataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(UserProducts userProducts)
        {
            await _context.UserProducts.AddAsync(userProducts);
            await _context.SaveChangesAsync();
        }

        public async Task<UserProducts> GetUserProducts(Guid userId, Guid productId)
        {
            var userProduct = await _context.UserProducts.AsNoTracking().FirstOrDefaultAsync(up => up.UserId == userId && up.ProductId == productId && up.DeletedAt == null);

            if (userProduct == null)
                return null;

            return userProduct;
        }

        public async Task<List<UserProducts>> GetUserProductsByUserId(Guid userId)
        {
            var userProduct = await _context.UserProducts.AsNoTracking()
                    .Include(x => x.User)
                    .Include(x => x.Product)
                    .Where(x => x.UserId == userId)
                    .Where(p => p.User.Id == userId)
                    .Where(t => t.DeletedAt == null)
                    .ToListAsync();



            if (userProduct == null)
                return null;

            return userProduct;
        }

        public void Update(UserProducts userProduct)
        {
            _context.UserProducts.Update(userProduct);
            _context.SaveChanges();
        }
    }
}
