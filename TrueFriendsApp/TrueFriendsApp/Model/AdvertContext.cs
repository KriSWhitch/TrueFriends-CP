using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TrueFriendsApp.Model
{
    class AdvertContext : DbContext
    {
        public AdvertContext(DbContextOptions<AdvertContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Advert> Advert { get; set; }

    }
}
