using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TrueFriendsApp.pages
{
    /// <summary>
    /// Логика взаимодействия для AdvertPage.xaml
    /// </summary>
    public partial class AdvertPage : UserControl
    {
        private object advertObject;
        private MainWindow mainForm;

        public AdvertPage(object sender, System.Windows.Input.MouseButtonEventArgs e, MainWindow mainForm)
        {
            InitializeComponent();
            var dataInRow = (DataGridRow)sender;
            advertObject = dataInRow.Item;
            this.mainForm = mainForm;
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            AdvertInGrid advert = (AdvertInGrid)advertObject;
            AdFullNameTextBox.Text = advert.FullName;
            AdShortNameTextBox.Text = advert.ShortName;
            AdRaitingTextBox.Text = (advert.Raiting).ToString();
            AdCategoryTextBox.Text = (advert.Category).ToString();
            AdCostTextBox.Text = (advert.Cost).ToString();
            AdAmountTextBox.Text = (advert.Amount).ToString();
            for (var i = 0; i < advert.Images.Count; i++)
            {
                if (i == 0)
                {
                    AdMainImage.Source = ImageConverter.ImageSourceFromBitmap(advert.Images[0].Source);
                    AdMainImageWrapper.Background = new SolidColorBrush(Colors.Transparent);
                }

                if (i == 1)
                {
                    AdSubImage1.Source = ImageConverter.ImageSourceFromBitmap(advert.Images[1].Source);
                    AdSubImage1Wrapper.Background = new SolidColorBrush(Colors.Transparent);
                }


                if (i == 2)
                {
                    AdSubImage2.Source = ImageConverter.ImageSourceFromBitmap(advert.Images[2].Source);
                    AdSubImage2Wrapper.Background = new SolidColorBrush(Colors.Transparent);
                }

                if (i == 3)
                {
                    AdSubImage3.Source = ImageConverter.ImageSourceFromBitmap(advert.Images[3].Source);
                    AdSubImage3Wrapper.Background = new SolidColorBrush(Colors.Transparent);
                }
            }
        }

        private void ButtonBackToHomePage_Click(object sender, RoutedEventArgs e)
        {
            mainForm.GridMain.Children.Clear();
            mainForm.GridMain.Children.Add(new HomePage(mainForm));
        }

        private void ButtonDeleteAdvert_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Вы уверены что хотите удалить объявление?", "Предупреждение", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                List<Advert> adList = Serialization.Deserialize();
                AdvertInGrid advert = (AdvertInGrid)advertObject;
                var item = adList.SingleOrDefault(x => x.ID == advert.ID);
                if (item != null)
                {
                    adList.Remove(item);
                    Serialization.Serialize(adList);
                    mainForm.GridMain.Children.Clear();
                    mainForm.GridMain.Children.Add(new HomePage(mainForm));
                }
                else
                {
                    MessageBox.Show("Ошибка!", "Сообщение об ошибке", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

        private void ButtonEditAdvert_Click(object sender, RoutedEventArgs e)
        {
            AdvertInGrid advert = (AdvertInGrid)advertObject;
            mainForm.GridMain.Children.Clear();
            mainForm.GridMain.Children.Add(new EditAdPage(advert));
        }

    }
}
