using InvestmentManager.Domain.Entities;

namespace InvestmentManager.Domain.Interfaces.Repositories
{
    public interface IUserProductsRepository
    {
        Task<UserProducts> GetUserProducts(Guid userId, Guid productId);
        Task<List<UserProducts>> GetUserProductsByUserId(Guid userId);
        Task AddAsync(UserProducts userProducts);
        void Update(UserProducts userProduct);
    }
}
