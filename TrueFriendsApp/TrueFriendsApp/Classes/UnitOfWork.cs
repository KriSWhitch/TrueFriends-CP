using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Text;
using TrueFriendsApp.Repository;
using TrueFriendsApp.Model;

namespace TrueFriendsApp.Classes
{
    static class UnitOfWork
    {

        private static string StringConnection = ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString;
        private static DbContextOptionsBuilder<DataContext> optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        private static DbContextOptions<DataContext> options = optionsBuilder.UseSqlServer(StringConnection).Options;
        private static DataContext db = new DataContext(options);
        private static AdvertRepository advertRepository;
        private static UserRepository userRepository;
        private static FavoriteRepository favoriteRepository;

        public static AdvertRepository Adverts
        {
            get
            {
                if (advertRepository == null)
                    advertRepository = new AdvertRepository(db);
                return advertRepository;
            }
        }

        public static UserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public static FavoriteRepository Favorites
        {
            get
            {
                if (favoriteRepository == null)
                    favoriteRepository = new FavoriteRepository(db);
                return favoriteRepository;
            }
        }
        public static void Save()
        {
            db.SaveChanges();
        }

        public static void Refresh()
        {
            db = new DataContext(options);
            advertRepository = new AdvertRepository(db);
            userRepository = new UserRepository(db);
            favoriteRepository = new FavoriteRepository(db);
        }
    }
}
