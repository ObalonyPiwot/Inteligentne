using DinkToPdf;
using DinkToPdf.Contracts;
using MyProject.Application.Profiles;
using MyProject.Domain.Authorization;
using MyProject.Persistance.Context;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            services.AddScoped<IMyProjectDbContext, MyProjectDbContext>();
            services.AddScoped<ICurrentUser, CurrentUserService>();

            services.AddAutoMapper(typeof(AutomapperProfile).Assembly);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
            services.AddSingleton<IConverter>(new SynchronizedConverter(new PdfTools()));
            return services;

            // part name label
        }
    }
}