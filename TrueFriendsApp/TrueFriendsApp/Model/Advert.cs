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
        private decimal animalWeight;
        private Picture image;
        private ImageSource imageSource = null;
        private string advertCreator;
        private string creationDate;

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
        public decimal AnimalWeight // Количество товара на складе
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
        public Picture Image // Картинка к объявлению
        {
            get { return image; }
            set { image = value; }
        } 
        public ImageSource ImageSource
        {
            get { return imageSource; }
            set { imageSource = value; }
        }
        public string AdvertCreator // Создатель объявления
        {
            get { return advertCreator; }
            set { advertCreator = value; }
        }
        public string CreationDate // Создатель объявления
        {
            get { return creationDate; }
            set { creationDate = value; }
        }

    }
}
