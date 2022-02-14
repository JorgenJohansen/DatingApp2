using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Interfaces;
using Services;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Data;
using Helpers;

namespace Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(options => {
                options.UseSqlite(config.GetConnectionString ("DefaultConnection"));
            });

            return services;
        }
    }
}