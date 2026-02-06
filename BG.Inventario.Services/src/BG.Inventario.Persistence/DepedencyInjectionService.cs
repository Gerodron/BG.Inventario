using BG.Inventario.Application.Database;
using BG.Inventario.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BG.Inventario.Persistence
{
    public static class DepedencyInjectionService
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseService>(opt =>
            {
                opt.UseSqlServer(configuration["SqlConnectionString"]);
            });
            services.AddScoped<IDatabaseService, DatabaseService>();
            return services;
        }
    }
}
