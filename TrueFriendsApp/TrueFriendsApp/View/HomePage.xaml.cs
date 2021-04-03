using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TrueFriendsApp.View
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : UserControl
    {
        MainWindow mainForm;

        public HomePage(MainWindow mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            List<Advert> adList = Serialization.Deserialize();
            foreach (var el in adList)
            {
                el.ImageSource = ImageConverter.ImageSourceFromBitmap(el.Image.Source);
            }
            MainGrid.ItemsSource = adList;
        }

        private void RowDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            mainForm.GridMain.Children.Clear();
            mainForm.GridMain.Children.Add(new AdvertPage(sender, e, mainForm));
        }
    }
}
