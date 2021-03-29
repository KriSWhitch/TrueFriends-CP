using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TrueFriendsApp.pages
{
    /// <summary>
    /// Логика взаимодействия для CreateAdPage.xaml
    /// </summary>
    public partial class CreateAdPage : UserControl
    {

        bool completenessFlag = false;

        public CreateAdPage()
        {
            InitializeComponent();
        }

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

        private void AddPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true && IsValidImage(openFileDialog.FileName))
            {
                if (AdMainImage.Source == null)
                {
                    AdMainImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                    AdMainImageButtonClose.Visibility = Visibility.Visible;
                    AdMainImageWrapper.Background = new SolidColorBrush(Colors.Transparent);
                }
                else if (AdSubImage1.Source == null)
                {
                    AdSubImage1.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                    AdSubImage1ButtonClose.Visibility = Visibility.Visible;
                    AdSubImage1Wrapper.Background = new SolidColorBrush(Colors.Transparent);
                }
                else if (AdSubImage2.Source == null)
                {
                    AdSubImage2.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                    AdSubImage2ButtonClose.Visibility = Visibility.Visible;
                    AdSubImage2Wrapper.Background = new SolidColorBrush(Colors.Transparent);
                }
                else if (AdSubImage3.Source == null)
                {
                    AdSubImage3.Source = new BitmapImage(new Uri(openFileDialog.FileName));
                    AdSubImage3ButtonClose.Visibility = Visibility.Visible;
                    AdSubImage3Wrapper.Background = new SolidColorBrush(Colors.Transparent);
                }
                else
                {
                    MessageBox.Show("Вы не можете добавить более 4-х фотографий!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Вы должны выбрать картинку!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AdMainImageButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            btn.Visibility = Visibility.Collapsed;
            ResetPicture(AdMainImage, AdMainImageWrapper);
        }

        private void AdSubImage1ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            btn.Visibility = Visibility.Collapsed;
            ResetPicture(AdSubImage1, AdSubImage1Wrapper);
        }

        private void AdSubImage2ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            btn.Visibility = Visibility.Collapsed;
            ResetPicture(AdSubImage2, AdSubImage2Wrapper);
        }

        private void AdSubImage3ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            btn.Visibility = Visibility.Collapsed;
            ResetPicture(AdSubImage3, AdSubImage3Wrapper);
        }

        private void CreateAdButton_Click(object sender, RoutedEventArgs e)
        {
            completenessFlag = false;
            if
            (
                ValidationRules.FullNameValidation(AdFullNameTextBox.Text) &&
                ValidationRules.ShortNameValidation(AdShortNameTextBox.Text) &&
                ValidationRules.RaitingValidation(AdRaitingTextBox.Text) &&
                ValidationRules.CostValidation(AdCostTextBox.Text) &&
                ValidationRules.CategoryValidation(AdCategoryTextBox.Text) &&
                ValidationRules.AmountValidation(AdAmountTextBox.Text) &&
                (AdMainImage.Source != null || AdSubImage1.Source != null || AdSubImage2.Source != null || AdSubImage3.Source != null)
            ) completenessFlag = true;
            CheckValidation(AdFullNameTextBox.Text, AdShortNameTextBox.Text, AdRaitingTextBox.Text, AdCostTextBox.Text, AdAmountTextBox.Text, AdCategoryTextBox.Text);
            if (completenessFlag)
            {
                Advert ad = new Advert();
                ad.ID = ad.GetID();
                ad.FullName = AdFullNameTextBox.Text;
                ad.ShortName = AdShortNameTextBox.Text;
                ad.Raiting = Double.Parse(AdRaitingTextBox.Text);
                ad.Cost = Convert.ToDecimal(AdCostTextBox.Text);
                ad.Category = AdCategoryTextBox.Text;
                ad.Amount = Convert.ToInt32(AdAmountTextBox.Text);
                if (AdMainImage.Source != null) ad.Images.Add(new Picture(ImageConverter.ConvertToBitmap(AdMainImage.Source as BitmapImage)));
                if (AdSubImage1.Source != null) ad.Images.Add(new Picture(ImageConverter.ConvertToBitmap(AdSubImage1.Source as BitmapImage)));
                if (AdSubImage2.Source != null) ad.Images.Add(new Picture(ImageConverter.ConvertToBitmap(AdSubImage2.Source as BitmapImage)));
                if (AdSubImage3.Source != null) ad.Images.Add(new Picture(ImageConverter.ConvertToBitmap(AdSubImage3.Source as BitmapImage)));
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
                FullNameValidationImage.Source = new BitmapImage(new Uri("../images/checked.png", UriKind.Relative));
                FullNameValidationImage.Visibility = Visibility.Visible;
            }
            else
            {
                FullNameValidationImage.Source = new BitmapImage(new Uri("../images/unchecked.png", UriKind.Relative));
                FullNameValidationImage.Visibility = Visibility.Visible;
            }
            if (ValidationRules.ShortNameValidation(shortName))
            {
                ShortNameValidationImage.Source = new BitmapImage(new Uri("../images/checked.png", UriKind.Relative));
                ShortNameValidationImage.Visibility = Visibility.Visible;
            }
            else
            {
                ShortNameValidationImage.Source = new BitmapImage(new Uri("../images/unchecked.png", UriKind.Relative));
                ShortNameValidationImage.Visibility = Visibility.Visible;
            }
            if (ValidationRules.RaitingValidation(raiting))
            {
                RaitingValidationImage.Source = new BitmapImage(new Uri("../images/checked.png", UriKind.Relative));
                RaitingValidationImage.Visibility = Visibility.Visible;
            }
            else
            {
                RaitingValidationImage.Source = new BitmapImage(new Uri("../images/unchecked.png", UriKind.Relative));
                RaitingValidationImage.Visibility = Visibility.Visible;
            }
            if (ValidationRules.CostValidation(cost))
            {
                CostValidationImage.Source = new BitmapImage(new Uri("../images/checked.png", UriKind.Relative));
                CostValidationImage.Visibility = Visibility.Visible;
            }
            else
            {
                CostValidationImage.Source = new BitmapImage(new Uri("../images/unchecked.png", UriKind.Relative));
                CostValidationImage.Visibility = Visibility.Visible;
            }
            if (ValidationRules.AmountValidation(amount))
            {
                AmountValidationImage.Source = new BitmapImage(new Uri("../images/checked.png", UriKind.Relative));
                AmountValidationImage.Visibility = Visibility.Visible;
            }
            else
            {
                AmountValidationImage.Source = new BitmapImage(new Uri("../images/unchecked.png", UriKind.Relative));
                AmountValidationImage.Visibility = Visibility.Visible;
            }
            if (ValidationRules.CategoryValidation(category))
            {
                CategoryValidationImage.Source = new BitmapImage(new Uri("../images/checked.png", UriKind.Relative));
                CategoryValidationImage.Visibility = Visibility.Visible;
            }
            else
            {
                CategoryValidationImage.Source = new BitmapImage(new Uri("../images/unchecked.png", UriKind.Relative));
                CategoryValidationImage.Visibility = Visibility.Visible;
            }
        }

        private void ResetPicture(System.Windows.Controls.Image img, Grid grid)
        {
            img.Source = null;
            grid.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(192, 192, 192));
        }
    }
}
