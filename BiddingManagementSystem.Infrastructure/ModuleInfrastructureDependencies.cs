using BiddingManagementSystem.Infrastructure.GenericRepository;
using Microsoft.Extensions.DependencyInjection;

namespace BiddingManagementSystem.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            // REGISTER GENERIC REPOSITORY
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));


            return services;
        }
    }
}
