using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Application.Api.Interfaces;
using Persistence.Api.Data;
using Infrastructure.Api.Repositories.Implementation;
using Infrastructure.Api.Services.Implementation;
using Infrastructure.Api.Services.Interfaces;

namespace Infrastructure.Api.Dependencies
{
    public static class DependencyResolver
    {
        public static void RepositoryResolver(this IServiceCollection services)
        {
            services.AddScoped<IDbContext, DataContext>();
            services.AddScoped<IValueRepository, ValueRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }
        public static void ServiceResolver(this IServiceCollection services)
        {
            services.AddScoped<IValueService, ValueService>();
            services.AddScoped<IUserService, UserService>();
        }
    }
}
