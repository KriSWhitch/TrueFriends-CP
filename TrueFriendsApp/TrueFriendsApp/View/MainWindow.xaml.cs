using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using TrueFriendsApp.View;
using TrueFriendsApp.ViewModel;

namespace TrueFriendsApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            Mouse.OverrideCursor = ((FrameworkElement)this.Resources["MouseCursor"]).Cursor;
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

        private void ButtonPopUpLogout_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void GitHubButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/KriSWhitch/TrueFriends-CP");
        }

        private void ButtonFAQ_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Version 1.0 ©KriSWhitch", "FAQ", MessageBoxButton.OK);
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            GridMain.Children.Add(new HomePage(this));
        }

        private void CreateAdButton_Click(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            GridMain.Children.Add(new CreateAdPage());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            HomeButton_Click(sender, e);
        }
    }
}
