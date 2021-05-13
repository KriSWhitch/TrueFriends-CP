using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TrueFriendsApp.Classes;
using TrueFriendsApp.Model;

namespace TrueFriendsApp.DB
{
    class SQLLocalServer : IRepository
    {
        private static string StringConnection = ConfigurationManager.ConnectionStrings["LocalConnection"].ConnectionString;
        private static DbContextOptionsBuilder<AdvertContext> optionsBuilder = new DbContextOptionsBuilder<AdvertContext>();
        private static DbContextOptions<AdvertContext> options = optionsBuilder.UseSqlServer(StringConnection).Options;
        private static DbContextOptionsBuilder<UserContext> optionsBuilderUser = new DbContextOptionsBuilder<UserContext>();
        private static DbContextOptions<UserContext> optionsUser = optionsBuilderUser.UseSqlServer(StringConnection).Options;
        private static DbContextOptionsBuilder<FavoriteContext> optionsBuilderFavorite = new DbContextOptionsBuilder<FavoriteContext>();
        private static DbContextOptions<FavoriteContext> optionsFavorite = optionsBuilderFavorite.UseSqlServer(StringConnection).Options;

        public BindingList<Advert> GetFavoriteAdverts(int userID)
        {
            BindingList<Advert> adverts = new BindingList<Advert>();
            BindingList<Advert> favoriteAdverts = new BindingList<Advert>();
            IEnumerable<Favorite> favorites = new List<Favorite>();
            try
            {
                AdvertContext dbAdvert = new AdvertContext(options);
                FavoriteContext dbFavorite = new FavoriteContext(optionsFavorite);
                dbAdvert.Advert.Load();
                dbFavorite.Favorite.Load();
                adverts = dbAdvert.Advert.Local.ToBindingList();
                favorites = dbFavorite.Favorite.Local.Where(x => x.Favorite_User_ID == userID);
                foreach (var fav in favorites)
                {
                    foreach (var ad in adverts)
                    {
                        if (fav.Favorite_Advert_ID == ad.Advert_ID) favoriteAdverts.Add(ad);
                    }
                }

                var tasks = new List<Task>();
                Parallel.ForEach(favoriteAdverts, el => {
                    tasks.Add(Task.Run(() =>
                    {
                        el.Advert_Picture = new Picture();
                        el.Advert_Picture.PictureString = el.Advert_Image;
                        el.Advert_ImageSource = ImageConverter.ImageSourceFromBitmap(el.Advert_Picture.Source);
                        el.Advert_ImageSource.Freeze();
                    }));
                });
                Task t = Task.WhenAll(tasks);
                t.Wait();
                return favoriteAdverts;
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return favoriteAdverts;
            }
        }

        public void AddToFavorite(int userID, int advertID)
        {
            try
            {
                FavoriteContext db = new FavoriteContext(optionsFavorite);
                Favorite favorite = new Favorite(userID, advertID);
                if (db.Favorite.Any(o => o.Favorite_User_ID == userID && o.Favorite_Advert_ID == advertID))
                {
                    db.Favorite.Remove(favorite);
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

        public BindingList<User> GetUsers()
        {
            BindingList<User> users = new BindingList<User>();
            try
            {
                UserContext db = new UserContext(optionsUser);
                db.User.Load();
                users = db.User.Local.ToBindingList();
                return users;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return users;
            }
        }

        public void AddUser(string login, string password)
        {
            try
            {
                UserContext db = new UserContext(optionsUser);
                User user = new User(login, password, false);
                db.User.Add(user);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException.Message);
            }
        }

        public void CreateAdvert(string name, int animalAge, decimal animalWeight, string kindOfAnimal, string description, string pictureString)
        {

            try
            {
                AdvertContext db = new AdvertContext(options);
                Advert ad = new Advert(name, animalAge, animalWeight, kindOfAnimal, description, pictureString, DateTime.Now);
                db.Advert.Add(ad);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException.Message);
            }
        }

        public void EditAdvert(int id, string name, int animalAge, decimal animalWeight, string kindOfAnimal, string description, string pictureString)
        {
            try
            {
                AdvertContext db = new AdvertContext(options);
                Advert ad = new Advert(id, name, animalAge, animalWeight, kindOfAnimal, description, pictureString, DateTime.Now);
                db.Advert.Update(ad);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void DeleteAdvert(Advert ad)
        {
            try
            {
                AdvertContext db = new AdvertContext(options);
                db.Advert.Remove(ad);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public BindingList<Advert> GetAdverts()
        {
            BindingList<Advert> adverts = new BindingList<Advert>();
            try
            {
                AdvertContext db = new AdvertContext(options);
                db.Advert.Load();
                adverts = db.Advert.Local.ToBindingList();
                var tasks = new List<Task>();
                Parallel.ForEach(adverts, el => {
                    tasks.Add(Task.Run(() =>
                    {
                        el.Advert_Picture = new Picture();
                        el.Advert_Picture.PictureString = el.Advert_Image;
                        el.Advert_ImageSource = ImageConverter.ImageSourceFromBitmap(el.Advert_Picture.Source);
                        el.Advert_ImageSource.Freeze();
                    }));
                });
                Task t = Task.WhenAll(tasks);
                t.Wait();
                return adverts;
            }

            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return adverts;
            }
        }

    }
}
