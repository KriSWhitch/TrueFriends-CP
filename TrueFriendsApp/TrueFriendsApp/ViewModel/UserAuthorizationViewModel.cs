using DevExpress.Mvvm;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
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

        public System.Windows.Input.ICommand signIn => new DelegateCommand(SignIn);
        private void SignIn()
        {
            if (ValidationRules.IsLoginValid(Login) && ValidationRules.IsPasswordValid(Password))
            {
                bool authorizationSuccessed= false;
                BindingList<User> users = DB.GetUsers();
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
