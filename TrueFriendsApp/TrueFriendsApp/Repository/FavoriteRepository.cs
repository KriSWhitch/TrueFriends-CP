using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TrueFriendsApp.Classes;
using TrueFriendsApp.Model;

namespace TrueFriendsApp.Repository
{
    class FavoriteRepository : IRepository<Favorite>
    {
        private DataContext db;
        private static string StringConnection = ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString;
        private static DbContextOptionsBuilder<DataContext> optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        private static DbContextOptions<DataContext> options = optionsBuilder.UseSqlServer(StringConnection).Options;

        public FavoriteRepository(DataContext context)
        {
            this.db = context;
        }

        public IEnumerable<Favorite> Get()
        {
            BindingList<Favorite> favorites = new BindingList<Favorite>();
            try
            {
                db.Favorite.Load();
                favorites = db.Favorite.Local.ToBindingList();
                return favorites;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return favorites;
            }
        }

        public void Create(Favorite favorite)
        {
            try
            {
                if (db.Favorite.Any(o => o.Favorite_User_ID == favorite.Favorite_User_ID && o.Favorite_Advert_ID == favorite.Favorite_Advert_ID))
                {
                    db.Favorite.Load();
                    var favorites = db.Favorite.Local.ToBindingList();
                    Favorite favoriteToRemove = (
                        from item in favorites 
                        where item.Favorite_User_ID == favorite.Favorite_User_ID && item.Favorite_Advert_ID == favorite.Favorite_Advert_ID 
                        select item
                    ).First();
                    db.Favorite.Remove(favoriteToRemove);
                    MessageBox.Show("Объявление убрано из избранного!");
                }
                else
                {
                    db.Favorite.Add(favorite);
                    MessageBox.Show("Объявление добавлено в избранное!");
                }
                db.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException.Message);
            }
        }


        public void Update(Favorite favorite)
        {
            try
            {
                db.Favorite.Update(favorite);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void Delete(Favorite favorite)
        {
            try
            {
                db.Favorite.Remove(favorite);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
