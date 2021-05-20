using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using TrueFriendsApp.Classes;
using TrueFriendsApp.Model;
using TrueFriendsApp.View;

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
            adList = UnitOfWork.GetLatestAdverts(3);
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
