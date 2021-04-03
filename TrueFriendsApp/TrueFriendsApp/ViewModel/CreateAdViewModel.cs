using DevExpress.Mvvm;
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
        private CreateAdPage view;

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


        public CreateAdViewModel(CreateAdPage viewModel)
        {
            this.view = viewModel;
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
            CheckValidation(FullName + "", ShortName + "", Raiting + "", Cost + "", Category + "", Amount + "");
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

        private void CheckValidation(string fullName, string shortName, string raiting, string cost, string amount, string category)
        {
            if (ValidationRules.FullNameValidation(fullName))
            {
                view.FullNameValidationImage.Source = new BitmapImage(new Uri("../images/checked.png", UriKind.Relative));
                view.FullNameValidationImage.Visibility = Visibility.Visible;
            }
            else
            {
                view.FullNameValidationImage.Source = new BitmapImage(new Uri("../images/unchecked.png", UriKind.Relative));
                view.FullNameValidationImage.Visibility = Visibility.Visible;
            }
            if (ValidationRules.ShortNameValidation(shortName))
            {
                view.ShortNameValidationImage.Source = new BitmapImage(new Uri("../images/checked.png", UriKind.Relative));
                view.ShortNameValidationImage.Visibility = Visibility.Visible;
            }
            else
            {
                view.ShortNameValidationImage.Source = new BitmapImage(new Uri("../images/unchecked.png", UriKind.Relative));
                view.ShortNameValidationImage.Visibility = Visibility.Visible;
            }
            if (ValidationRules.RaitingValidation(raiting))
            {
                view.RaitingValidationImage.Source = new BitmapImage(new Uri("../images/checked.png", UriKind.Relative));
                view.RaitingValidationImage.Visibility = Visibility.Visible;
            }
            else
            {
                view.RaitingValidationImage.Source = new BitmapImage(new Uri("../images/unchecked.png", UriKind.Relative));
                view.RaitingValidationImage.Visibility = Visibility.Visible;
            }
            if (ValidationRules.CostValidation(cost))
            {
                view.CostValidationImage.Source = new BitmapImage(new Uri("../images/checked.png", UriKind.Relative));
                view.CostValidationImage.Visibility = Visibility.Visible;
            }
            else
            {
                view.CostValidationImage.Source = new BitmapImage(new Uri("../images/unchecked.png", UriKind.Relative));
                view.CostValidationImage.Visibility = Visibility.Visible;
            }
            if (ValidationRules.AmountValidation(amount))
            {
                view.AmountValidationImage.Source = new BitmapImage(new Uri("../images/checked.png", UriKind.Relative));
                view.AmountValidationImage.Visibility = Visibility.Visible;
            }
            else
            {
                view.AmountValidationImage.Source = new BitmapImage(new Uri("../images/unchecked.png", UriKind.Relative));
                view.AmountValidationImage.Visibility = Visibility.Visible;
            }
            if (ValidationRules.CategoryValidation(category))
            {
                view.CategoryValidationImage.Source = new BitmapImage(new Uri("../images/checked.png", UriKind.Relative));
                view.CategoryValidationImage.Visibility = Visibility.Visible;
            }
            else
            {
                view.CategoryValidationImage.Source = new BitmapImage(new Uri("../images/unchecked.png", UriKind.Relative));
                view.CategoryValidationImage.Visibility = Visibility.Visible;
            }
        }

        private void ResetPicture(ImageSource img) //,Grid grid
        {
            img = null;
            //grid.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(192, 192, 192));
        }

    }
}
