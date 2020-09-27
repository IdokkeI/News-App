using System.Collections.Generic;

namespace news_server.Data.dbModels
{
    public class Profile
    {
        public int Id { get; set; }

        public List<User> Folowers { get; set; }

        public List<User> ListSubscribers { get; set; }


        public bool isBanned { get; set; }

    }
}
