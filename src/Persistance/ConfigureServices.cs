﻿using MyProject.Persistance.Context;
using MyProject.Persistance.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<AuditableEntitySaveChangesInterceptor>();

            services.AddDbContext<MyProjectDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("MyProjectDb"), builder => builder.MigrationsAssembly(typeof(MyProjectDbContext).Assembly.FullName)));
            return services;
        }
    }
}