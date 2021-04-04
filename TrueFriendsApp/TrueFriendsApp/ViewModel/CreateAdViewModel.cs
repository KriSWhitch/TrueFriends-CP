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
using TrueFriendsApp.View;

namespace TrueFriendsApp.ViewModel
{
    public class CreateAdViewModel : ViewModelBase
    {


        private MainWindow mainWindow;

        private int id;
        private string fullName;
        private string shortName;
        private string category;
        private double raiting;
        private decimal cost;
        private int amount;
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
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
                ValidationRules.FullNameValidation(FullName + "") &&
                ValidationRules.ShortNameValidation(ShortName + "") &&
                ValidationRules.RaitingValidation(Raiting + "") &&
                ValidationRules.CostValidation(Cost + "") &&
                ValidationRules.CategoryValidation(Category + "") &&
                ValidationRules.AmountValidation(Amount + "") &&
                (ImageSource != null)
            ) completenessFlag = true;
            CheckValidation(FullName + "", ShortName + "", Raiting + "", Cost + "", Amount + "", Category + "");
            if (completenessFlag)
            {
                Advert ad = new Advert();
                ad.ID = ad.GetID();
                ad.FullName = FullName;
                ad.ShortName = ShortName;
                ad.Raiting = Raiting;
                ad.Cost = Cost;
                ad.Category = Category;
                ad.Amount = Amount;
                if (ImageSource != null) ad.Image = new Picture(ImageConverter.ConvertToBitmap(ImageSource as BitmapImage));
                Serialization.Serialize(ad);
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
        private FontAwesomeIcon fullNameValidationIcon;
        private FontAwesomeIcon shortNameValidationIcon;
        private FontAwesomeIcon raitingValidationIcon;
        private FontAwesomeIcon costValidationIcon;
        private FontAwesomeIcon amountValidationIcon;
        private FontAwesomeIcon categoryValidationIcon;

        private Visibility fullNameValidationIconVisibility;
        private Visibility shortNameValidationIconVisibility;
        private Visibility raitingValidationIconVisibility;
        private Visibility costValidationIconVisibility;
        private Visibility amountValidationIconVisibility;
        private Visibility categoryValidationIconVisibility;

        public FontAwesomeIcon FullNameValidationIcon
        {
            get
            {
                return fullNameValidationIcon;
            }
            set
            {
                fullNameValidationIcon = value;
                RaisePropertyChanged("FullNameValidationIcon");
            }
        }
        public FontAwesomeIcon ShortNameValidationIcon
        {
            get
            {
                return shortNameValidationIcon;
            }
            set
            {
                shortNameValidationIcon = value;
                RaisePropertyChanged("ShortNameValidationIcon");
            }
        }
        public FontAwesomeIcon RaitingValidationIcon
        {
            get
            {
                return raitingValidationIcon;
            }
            set
            {
                raitingValidationIcon = value;
                RaisePropertyChanged("RaitingValidationIcon");
            }
        }
        public FontAwesomeIcon CostValidationIcon
        {
            get
            {
                return costValidationIcon;
            }
            set
            {
                costValidationIcon = value;
                RaisePropertyChanged("CostValidationIcon");
            }
        }
        public FontAwesomeIcon AmountValidationIcon
        {
            get
            {
                return amountValidationIcon;
            }
            set
            {
                amountValidationIcon = value;
                RaisePropertyChanged("AmountValidationIcon");
            }
        }
        public FontAwesomeIcon CategoryValidationIcon
        {
            get
            {
                return categoryValidationIcon;
            }
            set
            {
                categoryValidationIcon = value;
                RaisePropertyChanged("CategoryValidationIcon");
            }
        }

        public Visibility FullNameValidationIconVisibility
        {
            get
            {
                return fullNameValidationIconVisibility;
            }
            set
            {
                fullNameValidationIconVisibility = value;
                RaisePropertyChanged("FullNameValidationIconVisibility");
            }
        }
        public Visibility ShortNameValidationIconVisibility
        {
            get
            {
                return shortNameValidationIconVisibility;
            }
            set
            {
                shortNameValidationIconVisibility = value;
                RaisePropertyChanged("ShortNameValidationIconVisibility");
            }
        }
        public Visibility RaitingValidationIconVisibility
        {
            get
            {
                return raitingValidationIconVisibility;
            }
            set
            {
                raitingValidationIconVisibility = value;
                RaisePropertyChanged("RaitingValidationIconVisibility");
            }
        }
        public Visibility CostValidationIconVisibility
        {
            get
            {
                return costValidationIconVisibility;
            }
            set
            {
                costValidationIconVisibility = value;
                RaisePropertyChanged("CostValidationIconVisibility");
            }
        }
        public Visibility AmountValidationIconVisibility 
        {
            get
            {
                return amountValidationIconVisibility;
            }
            set
            {
                amountValidationIconVisibility = value;
                RaisePropertyChanged("AmountValidationIconVisibility");
            }
        } 
        public Visibility CategoryValidationIconVisibility {
            get
            {
                return categoryValidationIconVisibility;
            }
            set
            {
                categoryValidationIconVisibility = value;
                RaisePropertyChanged("CategoryValidationIconVisibility");
            } 
        }

        private void CheckValidation(string fullName, string shortName, string raiting, string cost, string amount, string category)
        {
            if (ValidationRules.FullNameValidation(fullName))
            {
                FullNameValidationIcon = FontAwesomeIcon.CheckCircle;
                FullNameValidationIconVisibility = Visibility.Visible;
            }
            else
            {
                FullNameValidationIcon = FontAwesomeIcon.MinusCircle;
                FullNameValidationIconVisibility = Visibility.Visible;
            }
            if (ValidationRules.ShortNameValidation(shortName))
            {
                ShortNameValidationIcon = FontAwesomeIcon.CheckCircle;
                ShortNameValidationIconVisibility = Visibility.Visible;
            }
            else
            {
                ShortNameValidationIcon = FontAwesomeIcon.MinusCircle;
                ShortNameValidationIconVisibility = Visibility.Visible;
            }
            if (ValidationRules.RaitingValidation(raiting))
            {
                RaitingValidationIcon = FontAwesomeIcon.CheckCircle;
                RaitingValidationIconVisibility = Visibility.Visible;
            }
            else
            {
                RaitingValidationIcon = FontAwesomeIcon.MinusCircle;
                RaitingValidationIconVisibility = Visibility.Visible;
            }
            if (ValidationRules.CostValidation(cost))
            {
                CostValidationIcon = FontAwesomeIcon.CheckCircle;
                CostValidationIconVisibility = Visibility.Visible;
            }
            else
            {
                CostValidationIcon = FontAwesomeIcon.MinusCircle;
                CostValidationIconVisibility = Visibility.Visible;
            }
            if (ValidationRules.AmountValidation(amount))
            {
                AmountValidationIcon = FontAwesomeIcon.CheckCircle;
                AmountValidationIconVisibility = Visibility.Visible;
            }
            else
            {
                AmountValidationIcon = FontAwesomeIcon.MinusCircle;
                AmountValidationIconVisibility = Visibility.Visible;
            }
            if (ValidationRules.CategoryValidation(category))
            {
                CategoryValidationIcon = FontAwesomeIcon.CheckCircle;
                CategoryValidationIconVisibility = Visibility.Visible;
            }
            else
            {
                CategoryValidationIcon = FontAwesomeIcon.MinusCircle;
                CategoryValidationIconVisibility = Visibility.Visible;
            }
        }

        private void ResetPicture(ImageSource img) //,Grid grid
        {
            img = null;
            //grid.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(192, 192, 192));
        }

    }
}
