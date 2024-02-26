using GestaoInvestimentos.Domain.Entities;

namespace GestaoInvestimentos.Domain.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        Task<Users> GetUserByIdAsync(Guid id);
        Task<List<Users>> GetAllUsers(string query);
        Task<Users> GetByPasswordAndEmailAsync(string email, string password);
        Task AddAsync(Users user);
        void Update(Users user);
    }
}
