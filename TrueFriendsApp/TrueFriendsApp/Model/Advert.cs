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
        private string kindOfAnimal;
        private string description;
        private int animalAge;
        private float animalWeight;
        private Picture image;
        private ImageSource imageSource = null;

        public int ID // Идентификатор объявления
        { 
            get { return id; } 
            set { id = value; } 
        } 
        public string FullName // Полное название объявления
        {
            get { return fullName; }
            set { fullName = value; }
        } 
        public string ShortName // Краткое название объявления
        {
            get { return shortName; }
            set { shortName = value; }
        }
        public int AnimalAge // Возраст животного
        {
            get { return animalAge; }
            set { animalAge = value; }
        }
        public float AnimalWeight // Количество товара на складе
        {
            get { return animalWeight; }
            set { animalWeight = value; }
        }
        public string KindOfAnimal // Вид животного
        {
            get { return kindOfAnimal; }
            set { kindOfAnimal = value; }
        } 
        public string Description // Описание объявления
        {
            get { return description; }
            set { description = value; }
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
