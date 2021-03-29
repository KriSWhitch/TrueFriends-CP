using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace TrueFriendsApp
{
    public class Advert
    {
        public int id;
        public string fullName;
        public string shortName;
        public string category;
        public double raiting;
        public decimal cost;
        public int amount;
        public List<Picture> images;

        public int ID // Идентификатор объявления
        { 
            get { return id; } 
            set
            {
                id = value;
                OnPropertyChanged("ID");
            } 
        } 
        public string FullName // Полное название товара
        {
            get { return fullName; }
            set
            {
                fullName = value;
                OnPropertyChanged("FullName");
            }
        } 
        public string ShortName // Краткое название товара
        {
            get { return shortName; }
            set
            {
                shortName = value;
                OnPropertyChanged("ShortName");
            }
        } 
        public string Category // Категория товара
        {
            get { return category; }
            set
            {
                category = value;
                OnPropertyChanged("Category");
            }
        } 
        public double Raiting // Рейтинг товара
        {
            get { return raiting; }
            set
            {
                raiting = value;
                OnPropertyChanged("Raiting");
            }
        } 
        public decimal Cost // Цена товара
        {
            get { return cost; }
            set
            {
                cost = value;
                OnPropertyChanged("Cost");
            }
        } 
        public int Amount // Количество товара на складе
        {
            get { return amount; }
            set
            {
                amount = value;
                OnPropertyChanged("Amount");
            }
        } 
        public List<Picture> Images { get; set; } = new List<Picture>(); // Картинки к объявлению

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
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
