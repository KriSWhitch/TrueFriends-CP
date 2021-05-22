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
    class AdvertRepository : IRepository<Advert>
    {
        private DataContext db;

        public AdvertRepository(DataContext context)
        {
            this.db = context;
        }

        public IEnumerable<Advert> Get()
        {
            BindingList<Advert> adverts = new BindingList<Advert>();
            try
            {
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

        public BindingList<Advert> GetLatestAdverts(int amount)
        {
            BindingList<Advert> adverts = new BindingList<Advert>();
            try
            {
                db.Advert.Load();
                adverts = db.Advert.Local.ToBindingList();
                adverts = new BindingList<Advert>(adverts.OrderByDescending(x => x.Advert_CreationDate).Take(amount).ToList());
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

        public IEnumerable<Advert> GetFavoriteAdverts(int userID)
        {
            BindingList<Advert> adverts = new BindingList<Advert>();
            BindingList<Advert> favoriteAdverts = new BindingList<Advert>();
            IEnumerable<Favorite> favorites = new List<Favorite>();
            try
            {
                db.Advert.Load();
                db.Favorite.Load();
                adverts = db.Advert.Local.ToBindingList();
                favorites = db.Favorite.Local.Where(x => x.Favorite_User_ID == userID);
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

        public void Create(Advert ad)
        {

            try
            {
                db.Advert.Add(ad);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException.Message);
            }
        }

        public void Update(Advert ad)
        {
            try
            {
                db.Advert.Update(ad);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void Delete(Advert ad)
        {
            try
            {
                db.Advert.Remove(ad);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
