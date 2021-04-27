using DevExpress.Mvvm;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using System.Windows.Input;
using TrueFriendsApp.Model;
using TrueFriendsApp.View;
using TrueFriendsApp.View.Windows;

namespace TrueFriendsApp.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
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
            }
        }

        private MainWindow mainForm;
        private User user;
        public User User
        {
            get { return user; }

            set { user = value; }
        }

        public Visibility CreateAdButtonVisibility { get; set; }

        public IMainWindowsCodeBehind CodeBehind { get; set; }

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
            CodeBehind.LoadView(MainWindowViewType.CreateAd);
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
            CodeBehind.LoadView(MainWindowViewType.Main);
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

        public ICommand buttonPopUpLogout => new DelegateCommand(ButtonPopUpLogout);
        public void ButtonPopUpLogout()
        {
            new AuthorizationWindow().Show();
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

        public ICommand gitHubButton => new DelegateCommand(GitHubButton);
        public void GitHubButton()
        {
            System.Diagnostics.Process.Start("explorer.exe", "https://github.com/KriSWhitch/TrueFriends-CP");
        }

        public ICommand buttonFAQ => new DelegateCommand(ButtonFAQ);
        public void ButtonFAQ()
        {
            MessageBox.Show("Version 1.0 ©KriSWhitch", "FAQ", MessageBoxButton.OK);
        }
    }
}
