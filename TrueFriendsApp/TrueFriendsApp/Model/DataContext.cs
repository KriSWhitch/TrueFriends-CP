using Microsoft.EntityFrameworkCore;

namespace TrueFriendsApp.Model
{
    class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Advert> Advert { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Favorite> Favorite { get; set; }
    }
}
