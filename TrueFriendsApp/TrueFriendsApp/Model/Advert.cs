using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Media;

namespace TrueFriendsApp
{
    public class Advert
    {
        private int advert_id;
        private string advert_name;
        private string advert_kindOfAnimal;
        private string advert_description;
        private int advert_animalAge;
        private decimal advert_animalWeight;
        private string advert_imageString;
        private Picture advert_image;
        private ImageSource advert_imageSource = null;
        private string advert_advertCreator;
        private DateTime advert_creationDate;

        [Key]
        public int Advert_ID // Идентификатор объявления
        { 
            get { return advert_id; } 
            set { advert_id = value; } 
        }
        public string Advert_Name // Название объявления
        {
            get { return advert_name; }
            set { advert_name = value; }
        }
        public int Advert_AnimalAge // Возраст животного
        {
            get { return advert_animalAge; }
            set { advert_animalAge = value; }
        }
        public decimal Advert_AnimalWeight // Вес животного
        {
            get { return advert_animalWeight; }
            set { advert_animalWeight = value; }
        }
        public string Advert_KindOfAnimal // Вид животного
        {
            get { return advert_kindOfAnimal; }
            set { advert_kindOfAnimal = value; }
        } 
        public string Advert_Description // Описание объявления
        {
            get { return advert_description; }
            set { advert_description = value; }
        }
        public string Advert_Image
        {
            get { return advert_imageString; }
            set { advert_imageString = value; }
        }
        [NotMapped]
        public Picture Advert_Picture // Картинка к объявлению
        {
            get { return advert_image; }
            set { advert_image = value; }
        }
        [NotMapped]
        public ImageSource Advert_ImageSource
        {
            get { return advert_imageSource; }
            set { advert_imageSource = value; }
        }
        public string Advert_Creator // Создатель объявления
        {
            get { return advert_advertCreator; }
            set { advert_advertCreator = value; }
        }
        public DateTime Advert_CreationDate // Создатель объявления
        {
            get { return advert_creationDate; }
            set { advert_creationDate = value; }
        }
        public Advert()
        {

        }
        public Advert(int id, string name, int animalAge, decimal animalWeight, string kindOfAnimal, string description, string pictureString, DateTime creationDate)
        {
            Advert_ID = id;
            Advert_Name = name;
            Advert_AnimalAge = animalAge;
            Advert_AnimalWeight = animalWeight;
            Advert_KindOfAnimal = kindOfAnimal;
            Advert_Description = description;
            Advert_Image = pictureString;
            Advert_CreationDate = creationDate;
        }
        public Advert(string name, int animalAge, decimal animalWeight, string kindOfAnimal, string description, string pictureString, DateTime creationDate)
        {
            Advert_Name = name;
            Advert_AnimalAge = animalAge;
            Advert_AnimalWeight = animalWeight;
            Advert_KindOfAnimal = kindOfAnimal;
            Advert_Description = description;
            Advert_Image = pictureString;
            Advert_CreationDate = creationDate;
        }
    }
}
