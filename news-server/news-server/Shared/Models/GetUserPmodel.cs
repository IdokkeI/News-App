using news_server.Features.Admin.Model;

namespace news_server.Shared.Models
{
    public class GetUserPmodel: GetUser
    {
        public int ProfileID { get; set; }
        
    }
}
