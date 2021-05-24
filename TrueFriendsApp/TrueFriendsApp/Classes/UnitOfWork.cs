using Microsoft.EntityFrameworkCore;
using System.Configuration;
using TrueFriendsApp.Repository;
using TrueFriendsApp.Model;
using System.Windows;

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
                Refresh();
                return advertRepository;
            }
        }

        public static UserRepository Users
        {
            get
            {
                Refresh();
                return userRepository;
            }
        }

        public static FavoriteRepository Favorites
        {
            get
            {
                Refresh();
                return favoriteRepository;
            }
        }
        public static void Save()
        {
            db.SaveChanges();
        }

        public static void Refresh()
        {
            try
            {
                db = new DataContext(options);
                advertRepository = new AdvertRepository(db);
                userRepository = new UserRepository(db);
                favoriteRepository = new FavoriteRepository(db);
            }
            catch
            {
                MessageBox.Show("Во время работы с базой данных произошла ошибка. Проверьте работу сервера, или попробуйте вернуться позже!");
                Application.Current.Shutdown();
            }
        }
    }
}
