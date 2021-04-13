using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Windows;
using TrueFriendsApp.Model;

namespace TrueFriendsApp
{
    public static class DB
    {
        private static string StringConnection = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private static DbContextOptionsBuilder<AdvertContext>  optionsBuilder = new DbContextOptionsBuilder<AdvertContext>();
        private static DbContextOptions<AdvertContext> options = optionsBuilder.UseSqlServer(StringConnection).Options;
        
        public static void CreateAdvert(string fullName, string shortName, int animalAge, decimal animalWeight, string kindOfAnimal, string description, byte[] pictureByteArray)
        {
            
            try
            {
                AdvertContext db = new AdvertContext(options);
                Advert ad = new Advert(fullName,shortName, animalAge, animalWeight, kindOfAnimal, description, pictureByteArray, DateTime.Now);
                db.Advert.Add(ad);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.InnerException.Message);
            }
        }

        public static void EditAdvert(int id, string fullName, string shortName, int animalAge, decimal animalWeight, string kindOfAnimal, string description, byte[] pictureByteArray)
        {
            try
            {
                AdvertContext db = new AdvertContext(options);
                Advert ad = new Advert(id, fullName, shortName, animalAge, animalWeight, kindOfAnimal, description, pictureByteArray, DateTime.Now);
                db.Advert.Update(ad);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void DeleteAdvert(Advert ad)
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

        public static BindingList<Advert> GetAdverts()
        {
            BindingList<Advert> adverts = new BindingList<Advert>();
            try
            {
                AdvertContext db = new AdvertContext(options);
                db.Advert.Load();
                adverts = db.Advert.Local.ToBindingList();
                foreach (var el in adverts)
                {
                    el.Advert_Picture = new Picture();
                    el.Advert_Picture.PictureByteArray = el.Advert_Image;
                    el.Advert_ImageSource = ImageConverter.ImageSourceFromBitmap(el.Advert_Picture.Source);
                }
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
