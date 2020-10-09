using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace news_server.Data.dbModels
{
    public class Subscriptions
    {
        [Key]
        public int ProfileId { get; set; }
        public Profile Profile { get; set; }
        public List<Profile> Subs { get; set; }
    }
}
