using DevExpress.Mvvm;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using TrueFriendsApp.View.Pages;
using TrueFriendsApp.View.Windows;

namespace TrueFriendsApp.ViewModel
{
    public interface IAuthorizationWindowCodeBehind
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
    class AuthorizationViewModel : ViewModelBase, IAuthorizationWindowCodeBehind
    {
        private AuthorizationWindow mainWindow;
        private object currentPage;
        public AuthorizationViewModel(AuthorizationWindow mainWindow)
        {
            this.mainWindow = mainWindow;
            LoadView(ViewType.Authorization);
        }

        public object CurrentPage 
        { 
            get 
            {
                return currentPage;
            }
            set
            {
                currentPage = value;
                RaisePropertyChanged("CurrentPage");
            }
        }

        public void LoadView(ViewType typeView)
        {
            switch (typeView)
            {
                case ViewType.Authorization:
                    //загружаем вьюшку, ее вьюмодель
                    UserAuthorizationPage viewAuthorization = new UserAuthorizationPage();
                    UserAuthorizationViewModel vmAuthorization = new UserAuthorizationViewModel(mainWindow);
                    //связываем их м/собой
                    vmAuthorization.CodeBehind = this;
                    viewAuthorization.DataContext = vmAuthorization;
                    //отображаем
                    CurrentPage = viewAuthorization;
                    break;
                case ViewType.Registration:
                    UserRegistrationPage viewRegistration = new UserRegistrationPage();
                    UserRegistrationViewModel vmRegistration = new UserRegistrationViewModel();
                    vmRegistration.CodeBehind = this;
                    viewRegistration.DataContext = vmRegistration;
                    CurrentPage = viewRegistration;
                    break;

            }
        }

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }



    }
}
