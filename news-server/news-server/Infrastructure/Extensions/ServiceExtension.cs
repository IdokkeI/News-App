using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using news_server.Data;
using news_server.Data.dbModels;
using news_server.Features.Identity;

namespace news_server.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = true;
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = Configuration.GetIssuer(),
                        ValidateAudience = true,
                        ValidAudience = Configuration.GetAudience(),
                        ValidateLifetime = true,
                        IssuerSigningKey = AuthConfiguration.GetSecurityKey(Configuration.GetSecurityKey())
                    };
                });
            return services;
        }

        public static IServiceCollection AddDataBaseContext(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<NewsDbContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("DefaultConnection")));
            return services;
        }

        public static IServiceCollection AddIdentityService(this IServiceCollection services)
        {
            services
                .AddIdentity<User, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = true;
                    options.Password.RequiredLength = 6;
                    options.Password.RequiredUniqueChars = 6;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                .AddEntityFrameworkStores<NewsDbContext>();
            return services;
        }

        public static IServiceCollection AddSwaggerService(this IServiceCollection services)
        {
            services
                .AddSwaggerGen(option =>
                    option.SwaggerDoc(
                        "NewsAPI",
                        new OpenApiInfo()
                        {
                            Title = "News API",
                            Version = "v1"
                        }
                    ));
            return services;
        }

        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddTransient<IIdentityService, IdentityService>();
            return services;
        }
    }
}
