using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace StruckApp.API.Configuration
{
    public static class AddSwaggerConfiguration
    {
        public static void AddSwaggerApiConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "StruckApp.API", Version = "v1"});
            });
        }
        
        public static void UseSwaggerApiConfiguration(this IApplicationBuilder app,  IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "StruckApp.API v1"));
            }
        }
        
        
    }
}