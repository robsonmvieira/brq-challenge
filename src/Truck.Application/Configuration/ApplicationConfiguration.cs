using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Truck.Application.Mapper;
using Truck.Application.Services;
using Truck.Application.Services.interfaces;
using TruckApp.Data.Configuration;
using TruckApp.Domain.Repositories;

namespace Truck.Application.Configuration
{
    public static class ApplicationConfiguration
    {
        public static void AddApplicationConfiguration(this IServiceCollection services, string connection)
        {
            services.AddDataConfiguration(connection);
            services.AddScoped<ITruckService, TruckService>();
            services.AddAutoMapper(typeof(TruckMapper));
        }
    }
}