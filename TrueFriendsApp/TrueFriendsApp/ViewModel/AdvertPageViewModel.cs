using DevExpress.Mvvm;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using TrueFriendsApp.Classes;
using TrueFriendsApp.Model;
using TrueFriendsApp.View;

namespace TrueFriendsApp.ViewModel
{
    class AdvertPageViewModel : ViewModelBase
    {
        private MainWindow mainForm;
        private MainWindowViewType prevView;
        private User user;
        private Advert ad;
        private int id;
        private string name;
        private string kindOfAnimal;
        private string description;
        private int animalAge;
        private decimal animalWeight;
        private Picture image;
        private ImageSource imageSource;
        public User User // Пользователь
        {
            get { return user; }
            set { user = value; }
        }
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
        public string Name // Полное название товара
        {
            get { return name; }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
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

        public MainWindowViewModel MainFormVM { get; set; }

        public AdvertPageViewModel(MainWindow mainForm, Advert ad, MainWindowViewType typeViewPrev)
        {
            this.mainForm = mainForm;
            prevView = typeViewPrev;
            MainFormVM = (MainWindowViewModel)mainForm.DataContext;
            User = MainFormVM.User;
            Ad = ad;
            ID = ad.Advert_ID;
            Name = ad.Advert_Name;
            KindOfAnimal = ad.Advert_KindOfAnimal;
            Description = ad.Advert_Description;
            AnimalWeight = ad.Advert_AnimalWeight;
            AnimalAge = ad.Advert_AnimalAge;
            Image = ad.Advert_Picture;
            ImageSource = ImageConverter.ImageSourceFromBitmap(ad.Advert_Picture.Source);
            if (!User.User_IsAdmin)
            {
                EditAdvertButtonVisibility = Visibility.Collapsed;
                DeleteAdvertButtonVisibility = Visibility.Collapsed;
            }
        }

        public Visibility EditAdvertButtonVisibility { get; set; }
        public Visibility DeleteAdvertButtonVisibility { get; set; }

        public ICommand buttonBackToPrevPage => new DelegateCommand(ButtonBackToPrevPage);
        private void ButtonBackToPrevPage()
        {
            mainForm.LoadView(prevView);
        }

        public ICommand buttonDeleteAdvert => new DelegateCommand(ButtonDeleteAdvert);
        private void ButtonDeleteAdvert()
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены что хотите удалить объявление?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                UnitOfWork.DeleteAdvert(Ad);
                mainForm.LoadView(MainWindowViewType.Main);
            }
        }
        public ICommand buttonEditAdvert => new DelegateCommand(ButtonEditAdvert);
        private void ButtonEditAdvert()
        {
            mainForm.LoadView(MainWindowViewType.EditAd, Ad);
        }

        public ICommand addToFavorite => new DelegateCommand(AddToFavorite);
        private void AddToFavorite()
        {
            UnitOfWork.AddToFavorite(User.User_ID, Ad.Advert_ID);
        }
    }
}
