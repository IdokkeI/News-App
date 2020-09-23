using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace news_server.Infrastructure
{
    public class AuthConfiguration
    {
        public static SymmetricSecurityKey GetSecurityKey(string key)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        }
    }
}
