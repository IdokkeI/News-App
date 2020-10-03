using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using news_server.Data;
using news_server.Data.dbModels;
using news_server.Features.Identity;
using Microsoft.IdentityModel.Tokens;
using news_server.Features.News;
using news_server.Features.Comment;
using news_server.Features.StatisticNews;
using news_server.Features.StatisticComment;

namespace news_server.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = true;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = Configuration.GetIssuer(),
                    ValidateAudience = true,
                    ValidAudience = Configuration.GetAudience(),
                    IssuerSigningKey = AuthConfiguration.GetSecurityKey(Configuration.GetSecurityKey()),
                    ValidateIssuerSigningKey = true
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
                    options.Password.RequiredLength = 6;
                    options.Password.RequireDigit = false;
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
            services.AddTransient<INewsService, NewsService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<StatisticNewsService>();
            services.AddTransient<StatisticCommentService>();
            return services;
        }
    }
}
