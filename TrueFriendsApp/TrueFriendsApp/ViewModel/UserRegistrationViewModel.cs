using DevExpress.Mvvm;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
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
    }


}
