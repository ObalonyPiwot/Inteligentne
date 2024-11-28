using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Infrastructure.Configuration;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigureServices
    {
        private const string _authScheme = JwtBearerDefaults.AuthenticationScheme;

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AuthoriseConfiguration>(configuration.GetSection("AuthoriseConfiguration"));

            services.AddAuthentication(_authScheme)
                .AddJwtBearer("Bearer", options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = configuration["AuthoriseConfiguration:Url"],
                        ValidAudience = configuration["AuthoriseConfiguration:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("78CNq33q2Hq7SvnA3vyXTlUAdxbiFAyIk5K3fLuzSj3lOyeDcYBJX6m6vGgxT22iqucEGv4FLKrkbQkQG" +
            "Aq9QDwz0EVgGDMrj02vOSgM26XFi0wfjVBBRXwnV6rhGSxsyfhnvKfssSzxJyWUGuYEbR9QLF4CWOIMIYw2rtquizvhL7UJjBIH"))
                    };
                });

            services.AddAuthorization();
            return services;
        }
    }
}