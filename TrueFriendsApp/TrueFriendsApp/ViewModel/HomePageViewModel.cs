using DevExpress.Mvvm;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
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
            CurrentSelection = Sorts.First();
            SortChangedClick();
        }

        private BindingList<Advert> adList = DB.GetAdverts();
        private Advert selectedItem;
        private Sort currentSelection;

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

        public List<Sort> Sorts { get; } = new List<Sort>
        {
            new Sort {SortType = "По названию"},
            new Sort {SortType = "По возр. возраста"},
            new Sort {SortType = "По убыв. возраста"},
            new Sort {SortType = "По возр. веса"},
            new Sort {SortType = "По убыв. веса"}
        };
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
            mainForm.LoadView(ViewType.Advert, SelectedItem);
        }

        public ICommand sortChangedClick => new DelegateCommand(SortChangedClick);
        private void SortChangedClick()
        {
            switch (CurrentSelection.SortType)
            {
                case "По названию":
                    var sortedShortNameList = new BindingList<Advert>(AdList.OrderBy(x => x.Advert_ShortName).ToList());
                    AdList = sortedShortNameList;
                    break;
                case "По возр. возраста":
                    var sortedAgeAscList = new BindingList<Advert>(AdList.OrderBy(x => x.Advert_AnimalAge).ToList());
                    AdList = sortedAgeAscList;
                    break;
                case "По убыв. возраста":
                    var sortedAgeDescList = new BindingList<Advert>(AdList.OrderByDescending(x => x.Advert_AnimalAge).ToList());
                    AdList = sortedAgeDescList;
                    break;
                case "По возр. веса":
                    var sortedWeightList = new BindingList<Advert>(AdList.OrderBy(x => x.Advert_AnimalWeight).ToList());
                    AdList = sortedWeightList;
                    break;
                case "По убыв. веса":
                    var sortedWeightDescList = new BindingList<Advert>(AdList.OrderByDescending(x => x.Advert_AnimalWeight).ToList());
                    AdList = sortedWeightDescList;
                    break;
            }
        }
    }
}
