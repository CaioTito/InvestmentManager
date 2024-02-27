using InvestmentManager.Domain.Entities;

namespace InvestmentManager.Domain.Interfaces.Repositories
{
    public interface IProductsRepository
    {
        Task<Products> GetProductByIdAsync(Guid id);
        Task<List<Products>> GetAllProducts(string query);
        Task AddAsync(Products product);
        void Update(Products product);
        List<Products> CheckProductExpiration();
    }
}
