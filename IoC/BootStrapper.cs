using Data;
using Data.Repositories.ProfileType;
using Data.Repositories.User;
using Domain;
using Domain.Entities.Enumx;
using Domain.Interfaces.ProfileType;
using Domain.Interfaces.User;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services) 
        {
            services.Scan(scan => scan
            .FromAssemblyOf<DataAssembly>()
            .AddClasses()
            .AsImplementedInterfaces()
            .WithScopedLifetime()
            
            .FromAssemblyOf<DomainAssembly>()
            .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<,>)))
            .AsSelfWithInterfaces()
            .WithTransientLifetime()
            );

            var domainAssembly = typeof(EnumExampleQuery).GetTypeInfo().Assembly;

            services.AddMediatR(new Assembly[]
            {
                domainAssembly
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProfileTypeRepository, ProfileTypeRepository>();
        }
    }
}
