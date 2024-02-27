using InvestmentManager.Domain.Entities;
using InvestmentManager.Domain.Interfaces.Repositories;
using InvestmentManager.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace InvestmentManager.Infra.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly InvestmentManagerDataContext _context;
        public UsersRepository(InvestmentManagerDataContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Users user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task<List<Users>> GetAllUsers(string query)
        {
            var users = await _context.Users.AsNoTracking().Where(u => u.Name.Contains(query) && u.DeletedAt == null).ToListAsync();

            if (users == null)
                return null;

            return users;
        }
        public async Task<Users> GetUserByIdAsync(Guid id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id && u.DeletedAt == null);

            if (user == null)
                return null;


            return user;
        }

        public void Update(Users user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public async Task<Users> GetByPasswordAndEmailAsync(string email, string password)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == email && u.Password == password && u.DeletedAt == null);

            if (user == null)
                return null;

            return user;
        }
    }
}
