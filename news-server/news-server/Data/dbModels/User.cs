using Microsoft.AspNetCore.Identity;

namespace news_server.Data.dbModels
{
    public class User: IdentityUser
    {
        public Profile Profile { get; set; }
        public int? ProfileId { get; set; }

      
    }
}
