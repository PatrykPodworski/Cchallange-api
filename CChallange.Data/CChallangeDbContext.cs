using Microsoft.EntityFrameworkCore;

namespace CChallange.Data
{
    public class CChallangeDbContext : DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Submition> Submitions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite(@"Data Source=C:\Projects\CChallangeAPI\CChallange.API\CChallange.Data\cchallange.db");
    }
}
