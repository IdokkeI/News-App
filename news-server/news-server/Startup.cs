using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using news_server.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using news_server.Data.dbModels;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using news_server.Infrastructure;
using news_server.Features.Identity;

namespace news_server
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
            =>
            Configuration = configuration;    
       
        public void ConfigureServices(IServiceCollection services)
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

            services.AddDbContext<NewsDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>(options => 
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
                .AddEntityFrameworkStores<NewsDbContext>();

            services.AddSwaggerGen(option =>
                option.SwaggerDoc(
                    "NewsAPI",
                    new OpenApiInfo()
                    {
                        Title ="News API",
                        Version = "v1"
                    }
                    ));

            services.AddTransient<IIdentityService, IdentityService>();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {               
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(options => 
                {
                    options.SwaggerEndpoint(
                        "/swagger/NewsAPI/swagger.json",
                        "NewsAPI");
                    options.RoutePrefix = string.Empty;
                });

            app.UseHttpsRedirection();
            app.UseCors(options =>
                options
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseRouting();
            
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
