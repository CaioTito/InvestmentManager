using GestaoInvestimentos.Domain.Entities;
using GestaoInvestimentos.Domain.Interfaces.Repositories;
using GestaoInvestimentos.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoInvestimentos.Infra.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly InvestmentManagerDataContext _context;
        public ProductsRepository(InvestmentManagerDataContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Products product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task<Products> GetProductByIdAsync(Guid id)
        {
            var product = await _context.Products.AsNoTracking().Include(p=> p.Category).FirstOrDefaultAsync(p => p.Id == id && p.DeletedAt == null);

            if (product == null)
                return null;

            return product;
        }

        public async Task<List<Products>> GetAllProducts(string query)
        {
            var products = await _context.Products.AsNoTracking().Include(p => p.Category).Where(p => p.Name.Contains(query) && p.DeletedAt == null).ToListAsync();

            if (products == null)
                return null;

            return products;
        }

        public void Update(Products product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public List<Products> CheckProductExpiration()
        {
            var products = _context.Products.AsNoTracking().Where(p => EF.Functions.DateDiffMonth(DateTime.Now, p.ExpirationDate) < 3 && p.DeletedAt == null).ToList();

            if (products == null)
                return null;

            return products;
        }
    }
}
