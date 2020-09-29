using System.Security.Claims;

namespace news_server.Infrastructure.Extensions
{
    public static class IdentityExtension
    {
        public static string GetUserName(this ClaimsPrincipal user)
        {
             return user.Identity?.Name;
        }
    }
}
