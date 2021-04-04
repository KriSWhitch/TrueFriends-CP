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
        private string category;
        private double raiting;
        private decimal cost;
        private int amount;
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
        public string Category // Категория товара
        {
            get { return category; }
            set
            {
                category = value;
                RaisePropertyChanged("Category");
            }
        }
        public double Raiting // Рейтинг товара
        {
            get { return raiting; }
            set
            {
                if (raiting != value)
                {
                    raiting = value;
                    RaisePropertyChanged("Raiting");
                }
            }
        }
        public decimal Cost // Цена товара
        {
            get { return cost; }
            set
            {
                cost = value;
                RaisePropertyChanged("Cost");
            }
        }
        public int Amount // Количество товара на складе
        {
            get { return amount; }
            set
            {
                amount = value;
                RaisePropertyChanged("Amount");
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
            Raiting = ad.Raiting;
            Cost = ad.Cost;
            Category = ad.Category;
            Amount = ad.Amount;
            Image = ad.Image;
            ImageSource = ImageConverter.ImageSourceFromBitmap(ad.Image.Source);
        }

        public AdvertPageViewModel(Advert ad)
        {
            Ad = ad;
            ID = ad.ID;
            FullName = ad.FullName;
            ShortName = ad.ShortName;
            Raiting = ad.Raiting;
            Cost = ad.Cost;
            Category = ad.Category;
            Amount = ad.Amount;
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
                List<Advert> adList = Serialization.Deserialize();
                var item = adList.SingleOrDefault(x => x.ID == ID);
                if (item != null)
                {
                    adList.Remove(item);
                    Serialization.Serialize(adList);
                    mainForm.LoadView(ViewType.Main);
                }
                else
                {
                    MessageBox.Show("Ошибка!", "Сообщение об ошибке", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }
        public ICommand buttonEditAdvert => new DelegateCommand(ButtonEditAdvert);
        private void ButtonEditAdvert()
        {
            mainForm.LoadView(ViewType.EditAd, Ad);
        }
    }
}
