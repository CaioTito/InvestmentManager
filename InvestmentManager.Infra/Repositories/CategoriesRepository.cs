using InvestmentManager.Domain.Entities;
using InvestmentManager.Domain.Interfaces.Repositories;
using InvestmentManager.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace InvestmentManager.Infra.Repositories
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly InvestmentManagerDataContext _context;

        public CategoriesRepository(InvestmentManagerDataContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(Guid id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(p => p.Id == id && p.DeletedAt == null);

            if (category == null)
                return null;

            return category;
        }

        public async Task<List<Category>> GetAllCategory(string query)
        {
            var category = await _context.Categories.AsNoTracking().Where(c => c.Name.Contains(query) && c.DeletedAt == null).ToListAsync();

            if (category == null)
                return null;

            return category;
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }
    }
}
