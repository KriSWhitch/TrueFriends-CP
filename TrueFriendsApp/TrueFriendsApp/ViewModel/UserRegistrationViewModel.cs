using DevExpress.Mvvm;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using TrueFriendsApp.Model;
using TrueFriendsApp.View.Windows;

namespace TrueFriendsApp.ViewModel
{
    class UserRegistrationViewModel : ViewModelBase
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

        private RelayCommand _LoadAuthorizationCommand;
        public RelayCommand LoadAuthorizationCommand
        {
            get
            {
                return _LoadAuthorizationCommand = _LoadAuthorizationCommand ??
                  new RelayCommand(OnLoadMain, CanLoadMain);
            }
        }
        private bool CanLoadMain()
        {
            return true;
        }
        private void OnLoadMain()
        {
            CodeBehind.LoadView(ViewType.Authorization);
        }

        public System.Windows.Input.ICommand signUp => new DelegateCommand(SignUp);
        private void SignUp()
        {
            if (ValidationRules.IsLoginValid(Login) && ValidationRules.IsPasswordValid(Password))
            {
                var userExistsFlag = false;
                BindingList<User> users = DB.GetUsers();
                foreach (User user in users)
                {
                    if (userExistsFlag == true) break;
                    if (user.User_Login == Login)
                    {
                        userExistsFlag = true;
                        MessageBox.Show("Пользователь с таким логином уже существует!");
                    }
                }
                if (userExistsFlag == false) {
                    DB.AddUser(Login, Encryption.Encrypt(Password));
                    MessageBox.Show("Ваш аккаунт был успешно создан!");
                }
            }
            else
            {
                MessageBox.Show("Логин или пароль введены некорректно!");
            }
        }
    }


}
