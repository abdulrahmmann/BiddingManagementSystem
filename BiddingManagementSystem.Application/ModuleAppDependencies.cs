using BiddingManagementSystem.Application.Features.UserFeature.Mapping;
using BiddingManagementSystem.Application.Validation;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace BiddingManagementSystem.Application
{
    public static class ModuleAppDependencies
    {
        public static IServiceCollection AddAppDependencies(this IServiceCollection services)
        {
            // Register MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            // Register AutoMapper
            services.AddAutoMapper(typeof(MappingProfileNewUser).Assembly);
            services.AddAutoMapper(typeof(MappingProfileLoginUser).Assembly);

            // Register Fluent Validators
            services.AddValidatorsFromAssembly(typeof(RegisterUserCommandValidator).Assembly);


            return services;
        }
    }
}
