using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrueFriendsApp.Model
{
    class FavoriteContext : DbContext
    {
        public FavoriteContext(DbContextOptions<FavoriteContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Favorite> Favorite { get; set; }
    }
}
