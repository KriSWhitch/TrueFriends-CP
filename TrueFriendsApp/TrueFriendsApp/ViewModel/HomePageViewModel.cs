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
using TrueFriendsApp.Classes;
using TrueFriendsApp.Model;
using TrueFriendsApp.View;

namespace TrueFriendsApp.ViewModel
{
    class HomePageViewModel : ViewModelBase
    {
        private MainWindow mainForm;
        private BindingList<Advert> adList;
        private BindingList<Advert> tmpList;
        private Advert selectedItem;
        private Sort currentSelection;
        private string searchText;

        public HomePageViewModel(MainWindow mainForm)
        {
            this.mainForm = mainForm;
            adList = UnitOfWork.GetAdverts();
            TmpList = AdList;
            CurrentSelection = Sorts.First();
            SortChangedClick();
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

        public BindingList<Advert> TmpList
        {
            get
            {
                return tmpList;
            }
            set
            {
                tmpList = value;
                RaisePropertyChanged("TmpList");
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
        
        public string SearchText
        {
            get
            {
                return searchText;
            }
            set
            {
                searchText = value;
                RaisePropertyChanged("SearchText");
            }
        }

        public ICommand rowDoubleClick => new DelegateCommand(RowDoubleClick);
        private void RowDoubleClick()
        {
            mainForm.LoadView(MainWindowViewType.Advert, SelectedItem);
        }

        public ICommand sortChangedClick => new DelegateCommand(SortChangedClick);
        private void SortChangedClick()
        {
            switch (CurrentSelection.SortType)
            {
                case "По названию":
                    var sortedNameList = new BindingList<Advert>(TmpList.OrderBy(x => x.Advert_Name).ToList());
                    TmpList = sortedNameList;
                    break;
                case "По возр. возраста":
                    var sortedAgeAscList = new BindingList<Advert>(TmpList.OrderBy(x => x.Advert_AnimalAge).ToList());
                    TmpList = sortedAgeAscList;
                    break;
                case "По убыв. возраста":
                    var sortedAgeDescList = new BindingList<Advert>(TmpList.OrderByDescending(x => x.Advert_AnimalAge).ToList());
                    TmpList = sortedAgeDescList;
                    break;
                case "По возр. веса":
                    var sortedWeightList = new BindingList<Advert>(TmpList.OrderBy(x => x.Advert_AnimalWeight).ToList());
                    TmpList = sortedWeightList;
                    break;
                case "По убыв. веса":
                    var sortedWeightDescList = new BindingList<Advert>(TmpList.OrderByDescending(x => x.Advert_AnimalWeight).ToList());
                    TmpList = sortedWeightDescList;
                    break;
            }
        }

        public ICommand buttonSearchAdvert => new DelegateCommand(ButtonSearchAdvert);
        private void ButtonSearchAdvert()
        {
            BindingList<Advert> tmpAdverts = new BindingList<Advert>();
            Regex regex = new Regex(@$"{SearchText}(\w*)", RegexOptions.IgnoreCase);
            foreach (var el in AdList)
            {
                MatchCollection matches = regex.Matches(el.Advert_Name);
                if (matches.Count > 0) tmpAdverts.Add(el);
            }
            TmpList = tmpAdverts;
            SortChangedClick();
        }

        public ICommand buttonClearSearch => new DelegateCommand(ButtonClearSearch);
        private void ButtonClearSearch()
        {
            TmpList = AdList;
            SortChangedClick();
            SearchText = "";
        }
        

    }
}
