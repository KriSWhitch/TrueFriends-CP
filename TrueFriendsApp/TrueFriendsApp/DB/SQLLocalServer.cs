using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
