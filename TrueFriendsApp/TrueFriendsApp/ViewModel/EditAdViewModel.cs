using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DevExpress.Mvvm;
using FontAwesome.WPF;
using Microsoft.Win32;
using TrueFriendsApp.Classes;
using TrueFriendsApp.View;

namespace TrueFriendsApp.ViewModel
{
    class EditAdViewModel : ViewModelBase
    {
        private MainWindowViewModel mainWindow;

        private int id;
        private string name;
        private string kindOfAnimal;
        private string description;
        private int animalAge;
        private decimal animalWeight;
        private Picture image;
        private ImageSource imageSource;

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
        public Advert Advert { get; set; }

        public EditAdViewModel(MainWindowViewModel mainWindow, Advert ad)
        {
            this.mainWindow = mainWindow;

            Advert = ad;
            ID = Advert.Advert_ID;
            Name = Advert.Advert_Name;
            KindOfAnimal = Advert.Advert_KindOfAnimal;
            Description = Advert.Advert_Description;
            AnimalAge = Advert.Advert_AnimalAge;
            AnimalWeight = Advert.Advert_AnimalWeight;
            ImageSource = ImageConverter.ImageSourceFromBitmap(Advert.Advert_Picture.Source);
        }

        bool completenessFlag = false;

        bool IsValidImage(string filename)
        {
            try
            {
                BitmapImage newImage = new BitmapImage(new Uri(filename));
            }
            catch (NotSupportedException)
            {
                return false;
            }
            return true;
        }
        public ICommand addPhotoButton => new DelegateCommand(AddPhotoButton);
        private void AddPhotoButton()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Images|*.jpg;*.jpeg;*.png",
                ValidateNames = true,
                CheckFileExists = false,
                CheckPathExists = true,
                Multiselect = false,
                Title = "Выберите файл"
            };
            if (openFileDialog.ShowDialog() == true && IsValidImage(openFileDialog.FileName))
            {
                ImageSource = new BitmapImage(new Uri(openFileDialog.FileName));
            }
        }

        public ICommand createAdButton => new DelegateCommand(CreateAdButton);
        private void CreateAdButton()
        {
            completenessFlag = false;
            if
            (
                ValidationRules.NameValidation(Name + "") &&
                ValidationRules.KindOfAnimalValidation(KindOfAnimal + "") &&
                ValidationRules.DescriptionValidation(Description + "") &&
                ValidationRules.AnimalAgeValidation(AnimalAge + "") &&
                ValidationRules.AnimalWeightValidation(AnimalWeight + "") &&
                (ImageSource != null)
            ) completenessFlag = true;
            CheckValidation(Name + "", KindOfAnimal + "", Description + "", AnimalAge + "", AnimalWeight + "");
            if (completenessFlag)
            {
                Image = new Picture(ImageConverter.ConvertToBitmapFromInteropBitmap(ImageSource));
                Advert.Advert_Name = Name;
                Advert.Advert_KindOfAnimal = KindOfAnimal;
                Advert.Advert_Description = Description;
                Advert.Advert_AnimalAge = AnimalAge;
                Advert.Advert_AnimalWeight = AnimalWeight;
                Advert.Advert_Picture = Image;
                Advert.Advert_Image = Advert.Advert_Picture.PictureString;
                UnitOfWork.Adverts.Update(Advert);
                MessageBox.Show(
                    "Объявление было успешно изменено!",
                    "Успех!",
                    MessageBoxButton.OK,
                    MessageBoxImage.None
                );
            }
            else
            {
                MessageBox.Show(
                    "Вы не заполнили все необходимые поля или заполнили их некорректно!",
                    "Сообщение об ошибке",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning
                );
            }
        }

        private FontAwesomeIcon nameValidationIcon;
        private FontAwesomeIcon kindOfAnimalValidationIcon;
        private FontAwesomeIcon descriptionValidationIcon;
        private FontAwesomeIcon animalAgeValidationIcon;
        private FontAwesomeIcon animalWeightValidationIcon;

        private Visibility nameValidationIconVisibility;
        private Visibility kindOfAnimalValidationIconVisibility;
        private Visibility descriptionValidationIconVisibility;
        private Visibility animalAgeValidationIconVisibility;
        private Visibility animalWeightValidationIconVisibility;

        public FontAwesomeIcon NameValidationIcon
        {
            get
            {
                return nameValidationIcon;
            }
            set
            {
                nameValidationIcon = value;
                RaisePropertyChanged("NameValidationIcon");
            }
        }
        public FontAwesomeIcon KindOfAnimalValidationIcon
        {
            get
            {
                return kindOfAnimalValidationIcon;
            }
            set
            {
                kindOfAnimalValidationIcon = value;
                RaisePropertyChanged("KindOfAnimalValidationIcon");
            }
        }
        public FontAwesomeIcon DescriptionValidationIcon
        {
            get
            {
                return descriptionValidationIcon;
            }
            set
            {
                descriptionValidationIcon = value;
                RaisePropertyChanged("DescriptionValidationIcon");
            }
        }
        public FontAwesomeIcon AnimalAgeValidationIcon
        {
            get
            {
                return animalAgeValidationIcon;
            }
            set
            {
                animalAgeValidationIcon = value;
                RaisePropertyChanged("AnimalAgeValidationIcon");
            }
        }
        public FontAwesomeIcon AnimalWeightValidationIcon
        {
            get
            {
                return animalWeightValidationIcon;
            }
            set
            {
                animalWeightValidationIcon = value;
                RaisePropertyChanged("AnimalWeightValidationIcon");
            }
        }

        public Visibility NameValidationIconVisibility
        {
            get
            {
                return nameValidationIconVisibility;
            }
            set
            {
                nameValidationIconVisibility = value;
                RaisePropertyChanged("NameValidationIconVisibility");
            }
        }
        public Visibility KindOfAnimalValidationIconVisibility
        {
            get
            {
                return kindOfAnimalValidationIconVisibility;
            }
            set
            {
                kindOfAnimalValidationIconVisibility = value;
                RaisePropertyChanged("KindOfAnimalValidationIconVisibility");
            }
        }
        public Visibility DescriptionValidationIconVisibility
        {
            get
            {
                return descriptionValidationIconVisibility;
            }
            set
            {
                descriptionValidationIconVisibility = value;
                RaisePropertyChanged("DescriptionValidationIconVisibility");
            }
        }
        public Visibility AnimalAgeValidationIconVisibility
        {
            get
            {
                return animalAgeValidationIconVisibility;
            }
            set
            {
                animalAgeValidationIconVisibility = value;
                RaisePropertyChanged("AnimalAgeValidationIconVisibility");
            }
        }
        public Visibility AnimalWeightValidationIconVisibility
        {
            get
            {
                return animalWeightValidationIconVisibility;
            }
            set
            {
                animalWeightValidationIconVisibility = value;
                RaisePropertyChanged("AnimalWeightValidationIconVisibility");
            }
        }

        private void CheckValidation(string name, string kindOfAnimal, string description, string animalAge, string animalWeight)
        {
            if (ValidationRules.NameValidation(name))
            {
                NameValidationIcon = FontAwesomeIcon.CheckCircle;
                NameValidationIconVisibility = Visibility.Visible;
            }
            else
            {
                NameValidationIcon = FontAwesomeIcon.MinusCircle;
                NameValidationIconVisibility = Visibility.Visible;
            }
            if (ValidationRules.KindOfAnimalValidation(kindOfAnimal))
            {
                KindOfAnimalValidationIcon = FontAwesomeIcon.CheckCircle;
                KindOfAnimalValidationIconVisibility = Visibility.Visible;
            }
            else
            {
                KindOfAnimalValidationIcon = FontAwesomeIcon.MinusCircle;
                KindOfAnimalValidationIconVisibility = Visibility.Visible;
            }
            if (ValidationRules.DescriptionValidation(description))
            {
                DescriptionValidationIcon = FontAwesomeIcon.CheckCircle;
                DescriptionValidationIconVisibility = Visibility.Visible;
            }
            else
            {
                DescriptionValidationIcon = FontAwesomeIcon.MinusCircle;
                DescriptionValidationIconVisibility = Visibility.Visible;
            }
            if (ValidationRules.AnimalAgeValidation(animalAge))
            {
                AnimalAgeValidationIcon = FontAwesomeIcon.CheckCircle;
                AnimalAgeValidationIconVisibility = Visibility.Visible;
            }
            else
            {
                AnimalAgeValidationIcon = FontAwesomeIcon.MinusCircle;
                AnimalAgeValidationIconVisibility = Visibility.Visible;
            }
            if (ValidationRules.AnimalWeightValidation(animalWeight))
            {
                AnimalWeightValidationIcon = FontAwesomeIcon.CheckCircle;
                AnimalWeightValidationIconVisibility = Visibility.Visible;
            }
            else
            {
                AnimalWeightValidationIcon = FontAwesomeIcon.MinusCircle;
                AnimalWeightValidationIconVisibility = Visibility.Visible;
            }
        }

        private void ResetPicture(ImageSource img) //,Grid grid
        {
            img = null;
            //grid.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(192, 192, 192));
        }

    }
}
