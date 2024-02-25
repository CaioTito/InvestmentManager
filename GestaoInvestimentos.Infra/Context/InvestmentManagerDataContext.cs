using GestaoInvestimentos.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GestaoInvestimentos.Infra.Context
{
    public class InvestmentManagerDataContext : DbContext
    {
        public InvestmentManagerDataContext(DbContextOptions<InvestmentManagerDataContext> options) : base(options)
        {
            
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<OperationType> OperationTypes { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<UserProducts> UserProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
