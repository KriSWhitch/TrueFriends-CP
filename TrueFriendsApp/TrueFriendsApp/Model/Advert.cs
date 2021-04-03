using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace TrueFriendsApp
{
    public class Advert
    {
        private int id;
        private string fullName;
        private string shortName;
        private string category;
        private double raiting;
        private decimal cost;
        private int amount;
        private Picture image;
        private ImageSource imageSource = null;

        public int ID // Идентификатор объявления
        { 
            get { return id; } 
            set { id = value; } 
        } 
        public string FullName // Полное название товара
        {
            get { return fullName; }
            set { fullName = value; }
        } 
        public string ShortName // Краткое название товара
        {
            get { return shortName; }
            set { shortName = value; }
        } 
        public string Category // Категория товара
        {
            get { return category; }
            set { category = value; }
        } 
        public double Raiting // Рейтинг товара
        {
            get { return raiting; }
            set { raiting = value; }
        } 
        public decimal Cost // Цена товара
        {
            get { return cost; }
            set { cost = value; }
        } 
        public int Amount // Количество товара на складе
        {
            get { return amount; }
            set { amount = value; }
        } 
        public Picture Image 
        {
            get { return image; }
            set { image = value; }
        } // Картинка к объявлению

        public ImageSource ImageSource
        {
            get { return imageSource; }
            set { imageSource = value; }
        }

        public int GetID()
        {
            bool uniquenessFlag = true;
            List<Advert> adList = Serialization.Deserialize();
            int unicID = 0;
            Random rnd = new Random();
            while (uniquenessFlag)
            {
                unicID = rnd.Next(0, 9999);
                var linqQuery = from ad in adList where ad.ID == unicID select ad;
                if (linqQuery.Count() == 0)
                {
                    uniquenessFlag = false;
                }
            }

            return unicID;
        }
    }
}
