using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using news_server.Features.Notify;
using news_server.Infrastructure.Extensions;
using news_server.Infrastructure.Filter;
using news_server.Infrastructure.MiddleWare;
using System.Net;

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
            services
                .AddDataBaseContext(Configuration)
                .AddIdentityService()
                .AddJwtAuthentication(Configuration)
                .AddAppServices()
                .AddSwaggerService()
                .AddCompression()
                .AddControllers(option => 
                    option.Filters.Add(typeof(DemoteFilter)));

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.KnownProxies.Add(IPAddress.Parse("165.227.158.125"));
            });

            services
                .AddSignalR();
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

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app
                .UseResponseCompression()
                .UseStaticFiles()
                .UseSwaggerMW()
                .UseCorsMW()
                .UseRouting()
                .UseAuthentication()
                .UseAuthorization()
                .UseLastActivity()
                .UseEndpoints(endpoints =>
                {                    
                    endpoints.MapControllers();
                    endpoints.MapHub<NotifyHub>("/notyficationHub");
                });
        }
    }
}
