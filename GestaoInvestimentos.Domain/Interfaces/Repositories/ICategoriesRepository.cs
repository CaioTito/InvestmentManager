using GestaoInvestimentos.Domain.Entities;

namespace GestaoInvestimentos.Domain.Interfaces.Repositories
{
    public interface ICategoriesRepository
    {
        Task<Category> GetCategoryByIdAsync(Guid id);
        Task<List<Category>> GetAllCategory(string query);
        Task AddAsync(Category category);
        void Update(Category category);
    }
}
