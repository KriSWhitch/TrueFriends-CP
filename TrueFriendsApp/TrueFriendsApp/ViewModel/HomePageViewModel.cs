using DevExpress.Mvvm;
using System.ComponentModel;
using System.Windows.Input;
using TrueFriendsApp.Classes;
using TrueFriendsApp.Model;

namespace TrueFriendsApp.ViewModel
{
    class HomePageViewModel : ViewModelBase
    {
        private MainWindowViewModel mainForm;
        private BindingList<Advert> adList;
        private Advert selectedItem;
        private Sort currentSelection;

        public HomePageViewModel(MainWindowViewModel mainForm)
        {
            this.mainForm = mainForm;
            adList = UnitOfWork.Adverts.GetLatestAdverts(3);
        }

        public BindingList<Advert> AdList
        {
            get
            {
                return adList;
            }
            set
            {
                adList = value;
                RaisePropertyChanged("AdList");
            }
        }
        public Advert SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
                RaisePropertyChanged("SelectedItem");
            }
        }

        public Sort CurrentSelection
        {
            get
            {
                return currentSelection;
            }
            set
            {
                currentSelection = value;
                RaisePropertyChanged("CurrentSelection");
            }
        }

        public ICommand rowDoubleClick => new DelegateCommand(RowDoubleClick);
        private void RowDoubleClick()
        {
            mainForm.LoadView(MainWindowViewType.Advert, SelectedItem, MainWindowViewType.Main);
        }

    }
}
