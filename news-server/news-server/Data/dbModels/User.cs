using Microsoft.AspNetCore.Identity;

namespace news_server.Data.dbModels
{
    public class User: IdentityUser
    {
        public string Photo { get; set; }

    }
}
