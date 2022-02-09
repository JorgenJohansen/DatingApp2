using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Interfaces;
using Services;
using API.Data;
using Microsoft.EntityFrameworkCore;

namespace Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddDbContext<DataContext>(options => {
                options.UseSqlite(config.GetConnectionString ("DefaultConnection"));
            });

            return services;
        }
    }
}