using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using TrueFriendsApp.View;

namespace TrueFriendsApp.ViewModel
{
    class AdvertPageViewModel : ViewModelBase
    {
        private MainWindow mainForm;

        private Advert ad;
        private int id;
        private string fullName;
        private string shortName;
        private string kindOfAnimal;
        private string description;
        private int animalAge;
        private decimal animalWeight;
        private Picture image;
        private ImageSource imageSource;
        public Advert Ad // Объявление
        {
            get { return ad; }
            set
            {
                ad = value;
                RaisePropertyChanged("Ad");
            }
        }
        public int ID // Идентификатор объявления
        {
            get { return id; }
            set
            {
                id = value;
                RaisePropertyChanged("ID");
            }
        }
        public string FullName // Полное название товара
        {
            get { return fullName; }
            set
            {
                fullName = value;
                RaisePropertyChanged("FullName");
            }
        }
        public string ShortName // Краткое название товара
        {
            get { return shortName; }
            set
            {
                shortName = value;
                RaisePropertyChanged("ShortName");
            }
        }
        public string KindOfAnimal // Категория товара
        {
            get { return kindOfAnimal; }
            set
            {
                kindOfAnimal = value;
                RaisePropertyChanged("KindOfAnimal");
            }
        }
        public string Description // Рейтинг товара
        {
            get { return description; }
            set
            {
                description = value;
                RaisePropertyChanged("Description");
            }
        }
        public decimal AnimalWeight // Цена товара
        {
            get { return animalWeight; }
            set
            {
                animalWeight = value;
                RaisePropertyChanged("AnimalWeight");
            }
        }
        public int AnimalAge // Количество товара на складе
        {
            get { return animalAge; }
            set
            {
                animalAge = value;
                RaisePropertyChanged("AnimalAge");
            }
        }

        public Picture Image
        {
            get { return image; }
            set
            {
                image = value;
                RaisePropertyChanged("Image");
            }
        } // Картинка к объявлению

        public ImageSource ImageSource
        {
            get { return imageSource; }
            set
            {
                imageSource = value;
                RaisePropertyChanged("ImageSource");
            }
        }

        public AdvertPageViewModel(MainWindow mainForm, Advert ad)
        {
            this.mainForm = mainForm;
            Ad = ad;
            ID = ad.ID;
            FullName = ad.FullName;
            ShortName = ad.ShortName;
            KindOfAnimal = ad.KindOfAnimal;
            Description = ad.Description;
            AnimalWeight = ad.AnimalWeight;
            AnimalAge = ad.AnimalAge;
            Image = ad.Image;
            ImageSource = ImageConverter.ImageSourceFromBitmap(ad.Image.Source);
        }

        public AdvertPageViewModel(Advert ad)
        {
            Ad = ad;
            ID = ad.ID;
            FullName = ad.FullName;
            ShortName = ad.ShortName;
            KindOfAnimal = ad.KindOfAnimal;
            Description = ad.Description;
            AnimalWeight = ad.AnimalWeight;
            AnimalAge = ad.AnimalAge;
            Image = ad.Image;
            ImageSource = ImageConverter.ImageSourceFromBitmap(ad.Image.Source);
        }

        public ICommand buttonBackToHomePage => new DelegateCommand(ButtonBackToHomePage);
        private void ButtonBackToHomePage()
        {
            mainForm.LoadView(ViewType.Main);
        }

        public ICommand buttonDeleteAdvert => new DelegateCommand(ButtonDeleteAdvert);
        private void ButtonDeleteAdvert()
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены что хотите удалить объявление?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                DB.DeleteAdvert(ID);
                mainForm.LoadView(ViewType.Main);
            }
        }
        public ICommand buttonEditAdvert => new DelegateCommand(ButtonEditAdvert);
        private void ButtonEditAdvert()
        {
            mainForm.LoadView(ViewType.EditAd, Ad);
        }
    }
}
