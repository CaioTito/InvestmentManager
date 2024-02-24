using GestaoInvestimentos.Domain.Interfaces.Repositories;
using GestaoInvestimentos.Domain.Interfaces.Services;
using GestaoInvestimentos.Infra.Auth;
using GestaoInvestimentos.Infra.Repositories;

namespace GestaoInvestimentos.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
