using InvestmentManager.Domain.Interfaces.Repositories;
using InvestmentManager.Domain.Interfaces.Services;
using InvestmentManager.Infra.Auth;
using InvestmentManager.Infra.Email;
using InvestmentManager.Infra.Repositories;
using Quartz;

namespace InvestmentManager.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<ICategoriesRepository, CategoriesRepository>();
            services.AddScoped<IOperationTypeRepository, OperationTypeRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IUserProductsRepository, UserProductsRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddTransient<IEmailService, EmailService>();
            
            services.AddQuartz(options =>
            {
                options.UseMicrosoftDependencyInjectionJobFactory();
            });
            services.AddQuartzHostedService(options => 
                {
                    options.WaitForJobsToComplete = true;
                });
            services.ConfigureOptions<EmailBackgroundJobSetup>();

            return services;
        }
    }
}
