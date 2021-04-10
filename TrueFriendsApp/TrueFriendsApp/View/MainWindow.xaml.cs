using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
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
        void LoadView(ViewType typeView);
    }

    /// <summary>
    /// Типы вьюшек для загрузки
    /// </summary>
    public enum ViewType
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
            //Подключаем выбор языка приложения
            App.LanguageChanged += LanguageChanged;
            CultureInfo currLang = App.Language;

            //Заполняем меню смены языка:
            ComboBoxLanguages.Items.Clear();
            foreach (var lang in App.Languages)
            {
                ComboBoxItem menuLang = new ComboBoxItem();
                menuLang.Content = lang.DisplayName;
                menuLang.Tag = lang;
                menuLang.IsSelected = lang.Equals(currLang);
                menuLang.Selected += ChangeLanguageClick;
                ComboBoxLanguages.Items.Add(menuLang);
            }
            ComboBoxLanguages.SelectedIndex = 1;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //загрузка вьюмодел для кнопок меню
            MainWindowViewModel vm = new MainWindowViewModel();
            //даем доступ к этому кодбихайнд
            vm.CodeBehind = this;
            //делаем эту вьюмодел контекстом данных
            this.DataContext = vm;
            //загрузка стартовой View
            LoadView(ViewType.Main);
        }

        public void LoadView(ViewType typeView)
        {
            switch (typeView)
            {
                case ViewType.Main:
                    //загружаем вьюшку, ее вьюмодель
                    HomePage view = new HomePage();
                    HomePageViewModel vm = new HomePageViewModel(this);
                    //связываем их м/собой
                    view.DataContext = vm;
                    //отображаем
                    this.OutputView.Content = view;
                    break;
                case ViewType.CreateAd:
                    CreateAdPage viewCreateAd = new CreateAdPage();
                    CreateAdViewModel vmCreateAd = new CreateAdViewModel(this);
                    viewCreateAd.DataContext = vmCreateAd;
                    this.OutputView.Content = viewCreateAd;
                    break;

            }
        }
        public void LoadView(ViewType typeView, Advert ad)
        {
            switch (typeView)
            {
                case ViewType.EditAd:
                    EditAdPage viewEditAd = new EditAdPage();
                    EditAdViewModel vmEditAd = new EditAdViewModel(this, ad);
                    viewEditAd.DataContext = vmEditAd;
                    this.OutputView.Content = viewEditAd;
                    break;
                case ViewType.Advert:
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

        private void LanguageChanged(object sender, EventArgs e)
        {
            CultureInfo currLang = App.Language;

            //Отмечаем нужный пункт смены языка как выбранный язык
            foreach (ComboBoxItem i in ComboBoxLanguages.Items)
            {
                CultureInfo ci = i.Tag as CultureInfo;
                i.IsSelected = ci != null && ci.Equals(currLang);
            }
        }

        private void ChangeLanguageClick(object sender, EventArgs e)
        {
            ComboBoxItem mi = sender as ComboBoxItem;
            if (mi != null)
            {
                CultureInfo lang = mi.Tag as CultureInfo;
                if (lang != null)
                {
                    App.Language = lang;
                }
            }
        }

    }
}
