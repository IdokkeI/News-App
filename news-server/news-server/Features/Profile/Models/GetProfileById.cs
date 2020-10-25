using news_server.Features.News.Models;
using System.Collections.Generic;

namespace news_server.Features.Profile.Models
{
    public class GetProfileById
    {
        public int ProfileId { get; set; }
        public string UserName { get; set; }
        public List<GetNewsModelWithStates> UserNews { get; set; }
                
    }
}
