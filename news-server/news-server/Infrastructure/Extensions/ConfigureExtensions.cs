using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using news_server.Data;

namespace news_server.Infrastructure.Extensions
{
    public static class ConfigureExtensions
    {
        public static IApplicationBuilder UseSwaggerMW(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint(
                    "/swagger/NewsAPI/swagger.json",
                    "NewsAPI");
                options.RoutePrefix = string.Empty;
            });
            return app;
        }

        public static IApplicationBuilder UseCorsMW(this IApplicationBuilder app)
        {
            app.UseCors(options =>
                options
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            return app;
        }

        public static void Migrate(this IApplicationBuilder app)
        {
            var services = app.ApplicationServices.CreateScope(); 
            var db = services.ServiceProvider.GetService<NewsDbContext>(); 
            db.Database.Migrate();
        }
    }
}
