using GestaoInvestimentos.Domain.Entities;

namespace GestaoInvestimentos.Domain.Interfaces.Repositories
{
    public interface IProductsRepository
    {
        Task<Products> GetProductByIdAsync(Guid id);
        Task AddAsync(Products product);
        void Update(Products product);
        List<Products> CheckProductExpiration();
    }
}
