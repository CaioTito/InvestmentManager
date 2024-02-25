using GestaoInvestimentos.Domain.Entities;
using GestaoInvestimentos.Domain.Interfaces.Repositories;
using GestaoInvestimentos.Infra.Context;

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

        public Task<UserProducts> ConsultProducts(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
