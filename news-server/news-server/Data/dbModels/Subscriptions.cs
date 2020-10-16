namespace news_server.Data.dbModels
{
    public class Subscriptions
    {
        public int Id { get; set; }

        public int ProfileId { get; set; }

        public Profile Profile { get; set; }

        public int ProfileIdSub{ get; set; }
    }
}
