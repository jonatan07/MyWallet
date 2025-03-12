using MediatR;
using MyWallet.Application.Commands.Operations.Create;
using MyWallet.Application.Commands.Wallets.Create;

namespace MyWallet.API.DependencyInjections
{
    public class MediatorDependencies
    {
        public static IServiceCollection AddDependencies(IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateWalletCommandHandler).Assembly));
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateOperationCommandHandler).Assembly));
            return services;
        }
    }
}
