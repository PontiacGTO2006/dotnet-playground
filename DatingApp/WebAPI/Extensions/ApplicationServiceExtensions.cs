using WebAPI.Data;
using Microsoft.EntityFrameworkCore;
using WebAPI.Interfaces;
using WebAPI.Services;

namespace WebAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<DataContext>(opt =>
            {
            opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            services.AddCors();
            services.AddScoped<ITokenService, TokenService>();

           return services;
        }
    }
}