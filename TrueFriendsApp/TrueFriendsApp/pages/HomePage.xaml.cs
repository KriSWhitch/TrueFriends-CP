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

namespace TrueFriendsApp.pages
{
    /// <summary>
    /// Логика взаимодействия для HomePage.xaml
    /// </summary>
    public partial class HomePage : UserControl
    {
        MainWindow mainForm;
        public List<AdvertInGrid> ResultCollection { get; set; }

        public HomePage(MainWindow mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
        }

        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
        {
            List<Advert> adList = Serialization.Deserialize();
            ResultCollection = new List<AdvertInGrid>();
            foreach (var el in adList)
            {
                ResultCollection.Add(new AdvertInGrid { FullName = el.FullName, ShortName = el.ShortName, Category = el.Category, Raiting = el.Raiting, Cost = el.Cost, Amount = el.Amount, AdvertImage = ImageConverter.ImageSourceFromBitmap(el.Images[0].Source), Images = el.Images, ID = el.ID });
            }
            MainGrid.ItemsSource = ResultCollection;
        }

        private void RowDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            mainForm.GridMain.Children.Clear();
            mainForm.GridMain.Children.Add(new AdvertPage(sender, e, mainForm));
        }
    }
}
