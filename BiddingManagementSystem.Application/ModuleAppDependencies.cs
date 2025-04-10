using BiddingManagementSystem.Application.Features.UserFeature.Mapping;
using BiddingManagementSystem.Application.UOF;
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

            // REGISTER UNIT OF WORK
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Register AutoMapper
            services.AddAutoMapper(typeof(MappingProfileNewUser));
            services.AddAutoMapper(typeof(MappingProfileLoginUser));
            //services.AddAutoMapper(typeof(MappingProfileTender));
            //services.AddAutoMapper(typeof(CreateTenderMappingProfile));

            // Register Fluent Validators
            services.AddValidatorsFromAssembly(typeof(RegisterUserCommandValidator).Assembly);
            services.AddValidatorsFromAssembly(typeof(TenderDTOValidator).Assembly);


            return services;
        }
    }
}
