using GestaoInvestimentos.Domain.Entities;
using GestaoInvestimentos.Domain.Interfaces.Repositories;
using GestaoInvestimentos.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoInvestimentos.Infra.Repositories
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

        public async Task<Users> GetUserByIdAsync(Guid id)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u=> u.Id == id);

            if (user == null)
                return null;

            if (user.DeletedAt != null)
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
            var user = await _context.Users.AsNoTracking().SingleOrDefaultAsync(u => u.Email == email && u.Password == password);

            if (user == null)
                return null;

            return user;
        }
    }
}
