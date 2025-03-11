using MyWallet.Domain.Interfaces;
using MyWallet.Infrastructure.Repositories;

namespace MyWallet.API.DependencyInjections
{
    public class RepositoryDependencies
    {
        public static IServiceCollection AddDependencies(IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<IOperationRepository, OperationRepository>();

            return services;
        }
    }
}
