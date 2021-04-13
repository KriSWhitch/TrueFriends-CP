using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using TrueFriendsApp.Model;
using TrueFriendsApp.View;

namespace TrueFriendsApp.ViewModel
{
    class HomePageViewModel : ViewModelBase
    {
        private MainWindow mainForm;
        public HomePageViewModel(MainWindow mainForm)
        {
            this.mainForm = mainForm;
        }
        
        private BindingList<Advert> adList = DB.GetAdverts();
        private Advert selectedItem;

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
        public ICommand rowDoubleClick => new DelegateCommand(RowDoubleClick);
        private void RowDoubleClick()
        {
            mainForm.LoadView(ViewType.Advert, SelectedItem);
        }
    }
}
