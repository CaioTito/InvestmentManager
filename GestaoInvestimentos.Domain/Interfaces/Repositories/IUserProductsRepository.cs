using GestaoInvestimentos.Domain.Entities;

namespace GestaoInvestimentos.Domain.Interfaces.Repositories
{
    public interface IUserProductsRepository
    {
        Task<UserProducts> GetUserProducts(Guid userId, Guid productId);
        Task AddAsync(UserProducts userProducts);
        void Update(UserProducts userProduct);
    }
}
