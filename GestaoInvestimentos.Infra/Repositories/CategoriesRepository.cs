using GestaoInvestimentos.Domain.Entities;
using GestaoInvestimentos.Domain.Interfaces.Repositories;
using GestaoInvestimentos.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoInvestimentos.Infra.Repositories
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
            var category = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            if (category == null)
                return null;

            if (category.DeletedAt != null)
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
