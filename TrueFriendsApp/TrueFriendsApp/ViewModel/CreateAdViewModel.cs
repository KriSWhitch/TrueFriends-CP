using DevExpress.Mvvm;
using FontAwesome.WPF;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using TrueFriendsApp.Classes;
using TrueFriendsApp.View;

namespace TrueFriendsApp.ViewModel
{
    public class CreateAdViewModel : ViewModelBase
    {


        private MainWindow mainWindow;

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
        public string Name // Краткое название товара
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

        public CreateAdViewModel(MainWindow mainWindow)
        {
            this.mainWindow = mainWindow;
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
                if (ImageSource == null)
                {
                    ImageSource = new BitmapImage(new Uri(openFileDialog.FileName));
                    //AdMainImageButtonClose.Visibility = Visibility.Visible;
                    //AdMainImageWrapper.Background = new SolidColorBrush(Colors.Transparent);
                }
                else
                {
                    MessageBox.Show("Вы не можете добавить более 1 фотографии!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Вы должны выбрать картинку!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public ICommand imageButtonClose => new DelegateCommand(ImageButtonClose);
        private void ImageButtonClose()
        {
            //Button btn = (Button)sender;
            //btn.Visibility = Visibility.Collapsed;
            //ResetPicture(ImageSource);
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
                Image = new Picture(ImageConverter.ConvertToBitmap(ImageSource as BitmapImage));
                UnitOfWork.CreateAdvert(Name, AnimalAge, AnimalWeight, KindOfAnimal, Description, Image.PictureString);
                MessageBox.Show(
                    "Объявление было успешно добавлено!",
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
        }

    }
}
