using Microsoft.Extensions.Configuration;

namespace news_server.Infrastructure
{
    public static class IConfigurationExtension
    {
        public static string GetIssuer(this IConfiguration configuration)
        {
            return configuration.GetSection("AuthConfig:Issuer").Value;
        }
        
        public static string GetAudience(this IConfiguration configuration)
        {
            return configuration.GetSection("AuthConfig:Audience").Value;
        }
        
        public static string GetSecurityKey(this IConfiguration configuration)
        {
            return configuration.GetSection("AuthConfig:SecurityKey").Value;
        }
        
        public static string GetLifeTime(this IConfiguration configuration)
        {
            return configuration.GetSection("AuthConfig:LifeTimeDays").Value;
        }
    }
}
