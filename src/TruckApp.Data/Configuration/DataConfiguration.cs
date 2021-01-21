using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TruckApp.Data.Data;
using TruckApp.Data.Repositories;
using TruckApp.Domain.Repositories;

namespace TruckApp.Data.Configuration
{
    public static class DataConfiguration
    {
        public static void AddDataConfiguration(this IServiceCollection services, string connection)
        {
            services.AddDbContext<TruckContext>(opt =>
            {
                opt.UseSqlServer(connection);
            });
            services.AddScoped<TruckContext>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ITruckRepository, TruckRepository>();
        }
    }
}