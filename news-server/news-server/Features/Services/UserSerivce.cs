using Microsoft.EntityFrameworkCore;
using news_server.Data;
using System.Linq;

namespace news_server.Features.Services
{
    public class UserSerivce
    {
        private readonly NewsDbContext context;

        public UserSerivce(NewsDbContext context)
        {
            this.context = context;
        }
        public string GetUserNameByProfileId(int id)
        {
            var username = context
                .Profiles
                .Include(p => p.User)
                .FirstOrDefault(p => p.Id == id).User.UserName;            

            return username;
        }

    }
}
