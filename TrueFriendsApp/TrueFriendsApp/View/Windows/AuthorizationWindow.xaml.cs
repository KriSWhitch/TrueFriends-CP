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
using System.Windows.Shapes;
using TrueFriendsApp.View.Pages;
using TrueFriendsApp.ViewModel;

namespace TrueFriendsApp.View.Windows
{
    public enum ViewType
    {
        Authorization,
        Registration
    }

    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
            //Пользовательская иконка мыши
            Mouse.OverrideCursor = ((FrameworkElement)this.Resources["MouseCursor"]).Cursor;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //загрузка вьюмодел для кнопок меню
            AuthorizationViewModel vm = new AuthorizationViewModel(this);
            //делаем эту вьюмодел контекстом данных
            this.DataContext = vm;
            //загрузка стартовой View
            vm.LoadView(ViewType.Authorization);
        }
    }
}
