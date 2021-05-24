using DevExpress.Mvvm;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using TrueFriendsApp.Classes;
using TrueFriendsApp.Model;
using TrueFriendsApp.View;
using TrueFriendsApp.View.Windows;
using ViewType = TrueFriendsApp.View.Windows.ViewType;

namespace TrueFriendsApp.ViewModel
{
    class UserAuthorizationViewModel : ViewModelBase
    {
        private string login;
        private string password;

        public string Login
        {
            get
            {
                return login;
            }
            set
            {
                login = value;
                RaisePropertyChanged("Login");
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                RaisePropertyChanged("Password");
            }
        }

        public IAuthorizationWindowCodeBehind CodeBehind { get; set; }
        public AuthorizationWindow Window { get; set; }

        public UserAuthorizationViewModel(AuthorizationWindow window)
        {
            Window = window;
        }

        private RelayCommand _LoadRegistrationCommand;
        public RelayCommand LoadRegistrationCommand
        {
            get
            {
                return _LoadRegistrationCommand = _LoadRegistrationCommand ??
                  new RelayCommand(OnLoadMain, CanLoadMain);
            }
        }
        private bool CanLoadMain()
        {
            return true;
        }
        private void OnLoadMain()
        {
            CodeBehind.LoadView(ViewType.Registration);
        }

        public ICommand<object> signIn => new DelegateCommand<object>(SignIn);
        private void SignIn(object param)
        {
            var passwordBox = param as PasswordBox;
            Password = passwordBox.Password;
            if (ValidationRules.IsLoginValid(Login) && ValidationRules.IsPasswordValid(Password))
            {
                bool authorizationSuccessed= false;
                IEnumerable<User> users = UnitOfWork.Users.Get();
                foreach (User user in users)
                {
                    if (user.User_Login == Login && user.User_Password == Encryption.Encrypt(Password))
                    {
                        authorizationSuccessed = true;
                        new MainWindow(user).Show();
                        Window.Close();
                    }
                }
                if (authorizationSuccessed == false) MessageBox.Show("Неверный логин или пароль!");
            }
            else
            {
                MessageBox.Show("Логин или пароль введены некорректно!");
            }
        }
    }
}
