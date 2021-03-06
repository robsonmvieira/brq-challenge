using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StruckApp.API.Configuration;
using Truck.Application.Configuration;

namespace StruckApp.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPresentationConfiguration();
            services.AddSwaggerApiConfiguration();
            services.AddAutoMapper(typeof(Startup));
            services.AddApplicationConfiguration(Configuration.GetConnectionString("DefaultConnection"));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UsePresentationConfiguration(env);
        }
    }
}