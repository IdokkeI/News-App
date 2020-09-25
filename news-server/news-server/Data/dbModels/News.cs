using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace news_server.Data.dbModels
{
    public class News
    {
        public int Id { get; set; }
        public string Section { get; set; }
        public string Title { get; set; }
        public string PhotoUrl { get; set; }
        public string Text { get; set; }
        public List<string> MeaterialPhotoUrl { get; set; } = new List<string>();
    }
}
