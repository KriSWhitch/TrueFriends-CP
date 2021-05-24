using DevExpress.Mvvm;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TrueFriendsApp.Classes;
using TrueFriendsApp.Model;
using TrueFriendsApp.View;
using TrueFriendsApp.View.Pages;
using TrueFriendsApp.View.Windows;

namespace TrueFriendsApp.ViewModel
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
        BrowseAdverts,
        CreateAd,
        Advert,
        EditAd,
        Favorite
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public class MainWindowViewModel : ViewModelBase, IMainWindowsCodeBehind
    {
        public MainWindowViewModel()
        {

        }
        public MainWindowViewModel(MainWindow mainForm, User user)
        {
            this.mainForm = mainForm;
            User = user;
            if (!User.User_IsAdmin)
            {
                CreateAdButtonVisibility = Visibility.Collapsed;
            } else
            {
                FavoriteButtonVisibility = Visibility.Collapsed;
            }
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
                    OutputView = view;
                    break;
                case MainWindowViewType.BrowseAdverts:
                    //загружаем вьюшку, ее вьюмодель
                    BrowseAdvertsPage viewBrowseAdverts = new BrowseAdvertsPage();
                    BrowseAdvertsViewModel vmBrowseAdverts = new BrowseAdvertsViewModel(this);
                    //связываем их м/собой
                    viewBrowseAdverts.DataContext = vmBrowseAdverts;
                    //отображаем
                    OutputView = viewBrowseAdverts;
                    break;
                case MainWindowViewType.CreateAd:
                    CreateAdPage viewCreateAd = new CreateAdPage();
                    CreateAdViewModel vmCreateAd = new CreateAdViewModel(this);
                    viewCreateAd.DataContext = vmCreateAd;
                    OutputView = viewCreateAd;
                    break;
                case MainWindowViewType.Favorite:
                    FavoritePage viewFavorite = new FavoritePage();
                    FavoritePageViewModel vmFavorite = new FavoritePageViewModel(this);
                    viewFavorite.DataContext = vmFavorite;
                    OutputView = viewFavorite;
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
                    OutputView = viewEditAd;
                    break;
            }
        }

        public void LoadView(MainWindowViewType typeView, Advert ad, MainWindowViewType typeViewPrev)
        {
            switch (typeView)
            {
                case MainWindowViewType.Advert:
                    AdvertPage viewAdvert = new AdvertPage();
                    AdvertPageViewModel vmAdvert = new AdvertPageViewModel(this, ad, typeViewPrev);
                    viewAdvert.DataContext = vmAdvert;
                    OutputView = viewAdvert;
                    break;

            }
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }


        private MainWindow mainForm;
        public UserControl outputView = null;
        private User user;
        public User User
        {
            get { return user; }

            set { user = value; }
        }

        public UserControl OutputView
        {
            get
            {
                return outputView;
            }
            set
            {
                outputView = value;
                RaisePropertyChanged("OutputView");
            }
        }

        public Visibility CreateAdButtonVisibility { get; set; }
        public Visibility FavoriteButtonVisibility { get; set; }

        private RelayCommand _LoadCreateAdPageCommand;
        public RelayCommand LoadCreateAdPageCommand
        {
            get
            {
                return _LoadCreateAdPageCommand = _LoadCreateAdPageCommand ??
                  new RelayCommand(OnLoadCreateAdPage, CanLoadCreateAdPage);
            }
        }
        private bool CanLoadCreateAdPage()
        {
            return true;
        }
        private void OnLoadCreateAdPage()
        {
            LoadView(MainWindowViewType.CreateAd);
        }

        // Страница для просмотра объявлений
        private RelayCommand _LoadBrowseAdvertsCommand;
        public RelayCommand LoadBrowseAdvertsCommand
        {
            get
            {
                return _LoadBrowseAdvertsCommand = _LoadBrowseAdvertsCommand ??
                  new RelayCommand(OnLoadBrowseAdverts, CanLoadBrowseAdverts);
            }
        }
        private bool CanLoadBrowseAdverts()
        {
            return true;
        }
        private void OnLoadBrowseAdverts()
        {
            LoadView(MainWindowViewType.BrowseAdverts);
        }

        // Возвращение к главной вьюшке
        private RelayCommand _LoadMainCommand;
        public RelayCommand LoadMainCommand
        {
            get
            {
                return _LoadMainCommand = _LoadMainCommand ??
                  new RelayCommand(OnLoadMain, CanLoadMain);
            }
        }
        private bool CanLoadMain()
        {
            return true;
        }
        private void OnLoadMain()
        {
            LoadView(MainWindowViewType.Main);
        }

        // Переход к избранным объявлениям
        private RelayCommand _LoadFavoriteCommand;
        public RelayCommand LoadFavoriteCommand
        {
            get
            {
                return _LoadFavoriteCommand = _LoadFavoriteCommand ??
                  new RelayCommand(OnLoadFavorite, CanLoadFavorite);
            }
        }
        private bool CanLoadFavorite()
        {
            return true;
        }
        private void OnLoadFavorite()
        {
            LoadView(MainWindowViewType.Favorite);
        }

        private Visibility buttonOpenMenuVisibility = Visibility.Visible;
        private Visibility buttonCloseMenuVisibility = Visibility.Collapsed;

        public Visibility ButtonOpenMenuVisibility
        {
            get
            {
                return buttonOpenMenuVisibility;
            }
            set
            {
                buttonOpenMenuVisibility = value;
                RaisePropertyChanged("ButtonOpenMenuVisibility");
            }
        }
        public Visibility ButtonCloseMenuVisibility
        {
            get
            {
                return buttonCloseMenuVisibility;
            }
            set
            {
                buttonCloseMenuVisibility = value;
                RaisePropertyChanged("ButtonCloseMenuVisibility");
            }
        }
        
        public ICommand windowLoaded => new DelegateCommand(WindowLoaded);
        public void WindowLoaded()
        {
            LoadView(MainWindowViewType.Main);
        }

        public ICommand buttonPopUpLogout => new DelegateCommand(ButtonPopUpLogout);
        public void ButtonPopUpLogout()
        {
            new AuthorizationWindow().Show();
            mainForm.Close();
        }

        public ICommand buttonPopUpRefresh => new DelegateCommand(ButtonPopUpRefresh);
        public void ButtonPopUpRefresh()
        {
            IEnumerable<User> users = UnitOfWork.Users.Get();
            foreach (User user in users)
            {
                if (user.User_Login == User.User_Login && user.User_Password == User.User_Password)
                {
                    new MainWindow(user).Show();
                }
            }
            mainForm.Close();
        }

        public ICommand buttonCloseMenu => new DelegateCommand(ButtonCloseMenu);
        public void ButtonCloseMenu()
        {
            ButtonOpenMenuVisibility = Visibility.Visible;
            ButtonCloseMenuVisibility = Visibility.Collapsed;
        }

        public ICommand buttonOpenMenu => new DelegateCommand(ButtonOpenMenu);
        public void ButtonOpenMenu()
        {
            ButtonOpenMenuVisibility = Visibility.Collapsed;
            ButtonCloseMenuVisibility = Visibility.Visible;
        }

        public ICommand buttonFAQ => new DelegateCommand(ButtonFAQ);
        public void ButtonFAQ()
        {
            MessageBox.Show("Version 1.0 ©KriSWhitch", "FAQ", MessageBoxButton.OK);
        }
    }
}
