using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using news_server.Data.dbModels;

namespace news_server.Data
{
    public class NewsDbContext : IdentityDbContext<User>
    {
        
        public NewsDbContext(DbContextOptions<NewsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<StatisticNews> StatisticNews { get; set; }
        public DbSet<StatisticComment> StatisticComments { get; set; }
        public DbSet<SectionsName> SectionsNames { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Comment> Comments { get; set; }
        
    }
}
