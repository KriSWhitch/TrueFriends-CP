using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using TrueFriendsApp.ViewModel;

namespace TrueFriendsApp.View
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
            DataContext = new AdvertPageViewModel((Advert)advertObject);
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
                Advert advert = (Advert)advertObject;
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
            Advert advert = (Advert)advertObject;
            mainForm.GridMain.Children.Clear();
            mainForm.GridMain.Children.Add(new EditAdPage(advert));
        }

    }
}
