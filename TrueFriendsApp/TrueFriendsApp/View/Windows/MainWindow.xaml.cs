using System.Windows;
using System.Windows.Input;
using TrueFriendsApp.Model;
using TrueFriendsApp.ViewModel;

namespace TrueFriendsApp.View
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Mouse.OverrideCursor = ((FrameworkElement)this.Resources["MouseCursor"]).Cursor;
            MainWindowViewModel vm = new MainWindowViewModel();
            DataContext = vm;
        }

        public MainWindow(User user)
        {
            InitializeComponent();
            Mouse.OverrideCursor = ((FrameworkElement)this.Resources["MouseCursor"]).Cursor;
            MainWindowViewModel vm = new MainWindowViewModel(this, user);
            DataContext = vm;
        }

    }
}
