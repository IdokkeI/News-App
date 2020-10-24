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
using news_server.Features.Admin;
using news_server.Features.Moderator;
using news_server.Infrastructure.Filter;
using news_server.Features.Subscriber;
using news_server.Features.Notify;
using Microsoft.AspNetCore.SignalR;
using news_server.Features.Notify.Provider;
using news_server.Features.Profile;
using news_server.Features.Services;
using news_server.Features.SectionNames;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using System.IO.Compression;
using System.Linq;

namespace news_server.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddCompression(this IServiceCollection services)
        {
            services
                .AddResponseCompression(option =>
                {
                    option.EnableForHttps = true;
                    option.MimeTypes = ResponseCompressionDefaults
                            .MimeTypes
                            .Concat(new[]
                            {
                                "application/json",
                                "text/plain",
                                "text/json"
                            });
                    option.Providers.Add<BrotliCompressionProvider>();
                    option.Providers.Add<GzipCompressionProvider>();
                })
                .Configure<BrotliCompressionProviderOptions>(option =>
                     option.Level = CompressionLevel.Optimal)
                .Configure<GzipCompressionProviderOptions>(option =>
                    option.Level = CompressionLevel.Optimal);
            return services;
        }

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
               options.UseMySql(
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
            services.AddTransient<IAdminService, AdminService>();
            services.AddTransient<IModeratorService, ModeratorService>();
            services.AddTransient<BanFilter>();
            services.AddTransient<DemoteFilter>();
            services.AddTransient<ISubService, SubService>();
            services.AddTransient<INotificationService, NotificationService>();
            services.AddTransient<IUserIdProvider, NewsUserProvider>();
            services.AddTransient<IProfileService, ProfileService>();
            services.AddTransient<UserSerivce>();
            services.AddTransient<ISectionService, SectionService>();

            return services;
        }
    }
}
