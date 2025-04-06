using BiddingManagementSystem.Domain.IRepository;
using BiddingManagementSystem.Infrastructure.GenericRepository;
using BiddingManagementSystem.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BiddingManagementSystem.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            // REGISTER GENERIC REPOSITORY
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            //REGISTER REPOSITORIES
            services.AddScoped<ITenderRepository, TenderRepository>();

            return services;
        }
    }
}
