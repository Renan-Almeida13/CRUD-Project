using Data;
using Data.Repositories.User;
using Domain;
using Domain.Entities.Enumx;
using Domain.Interfaces.User;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
