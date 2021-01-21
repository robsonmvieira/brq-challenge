using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace StruckApp.API.Configuration
{
    public static class AddApiConfiguration
    {
        public static void AddPresentationConfiguration(this IServiceCollection services)
        {
            services.AddControllers();
        }

        public static void UsePresentationConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwaggerApiConfiguration(env);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}