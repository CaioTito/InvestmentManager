using GestaoInvestimentos.Domain.Entities;

namespace GestaoInvestimentos.Domain.Interfaces.Repositories
{
    public interface IUserProductsRepository
    {
        Task<UserProducts> ConsultProducts(Guid id);
        Task AddAsync(UserProducts userProducts);
    }
}
