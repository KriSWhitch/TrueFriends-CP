using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TrueFriendsApp.Model;
using TrueFriendsApp.View;
using TrueFriendsApp.ViewModel;

namespace TrueFriendsApp.View
{
    public interface IMainWindowsCodeBehind
    {
        /// <summary>
        /// Показ сообщения для пользователя
        /// </summary>
        /// <param name="message">текст сообщения</param>
        void ShowMessage(string message);

        /// <summary>
        /// Загрузка нужной View
        /// </summary>
        /// <param name="view">экземпляр UserControl</param>
        void LoadView(MainWindowViewType typeView);
    }

    /// <summary>
    /// Типы вьюшек для загрузки
    /// </summary>
    public enum MainWindowViewType
    {
        Main,
        CreateAd,
        Advert,
        EditAd
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IMainWindowsCodeBehind
    {
        public MainWindow()
        {
            InitializeComponent();
            //Пользовательская иконка мыши
            Mouse.OverrideCursor = ((FrameworkElement)this.Resources["MouseCursor"]).Cursor;
            //загрузка вьюмодел для кнопок меню
            MainWindowViewModel vm = new MainWindowViewModel();
            //даем доступ к этому кодбихайнд
            vm.CodeBehind = this;
            //делаем эту вьюмодел контекстом данных
            this.DataContext = vm;
        }

        public MainWindow(User user)
        {
            InitializeComponent();
            Mouse.OverrideCursor = ((FrameworkElement)this.Resources["MouseCursor"]).Cursor;
            MainWindowViewModel vm = new MainWindowViewModel(this, user);
            vm.CodeBehind = this;
            this.DataContext = vm;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //загрузка стартовой View
            LoadView(MainWindowViewType.Main);
        }

        public void LoadView(MainWindowViewType typeView)
        {
            switch (typeView)
            {
                case MainWindowViewType.Main:
                    //загружаем вьюшку, ее вьюмодель
                    HomePage view = new HomePage();
                    HomePageViewModel vm = new HomePageViewModel(this);
                    //связываем их м/собой
                    view.DataContext = vm;
                    //отображаем
                    this.OutputView.Content = view;
                    break;
                case MainWindowViewType.CreateAd:
                    CreateAdPage viewCreateAd = new CreateAdPage();
                    CreateAdViewModel vmCreateAd = new CreateAdViewModel(this);
                    viewCreateAd.DataContext = vmCreateAd;
                    this.OutputView.Content = viewCreateAd;
                    break;

            }
        }
        public void LoadView(MainWindowViewType typeView, Advert ad)
        {
            switch (typeView)
            {
                case MainWindowViewType.EditAd:
                    EditAdPage viewEditAd = new EditAdPage();
                    EditAdViewModel vmEditAd = new EditAdViewModel(this, ad);
                    viewEditAd.DataContext = vmEditAd;
                    this.OutputView.Content = viewEditAd;
                    break;
                case MainWindowViewType.Advert:
                    AdvertPage viewAdvert = new AdvertPage();
                    AdvertPageViewModel vmAdvert = new AdvertPageViewModel(this, ad);
                    viewAdvert.DataContext = vmAdvert;
                    this.OutputView.Content = viewAdvert;
                    break;

            }
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

    }
}
