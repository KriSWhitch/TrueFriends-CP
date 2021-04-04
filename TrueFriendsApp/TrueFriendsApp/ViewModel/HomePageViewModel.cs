using DevExpress.Mvvm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
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

        private List<Advert> adList = Serialization.Deserialize();
        private Advert selectedItem;

        public List<Advert> AdList
        {
            get
            {
                foreach (var el in adList)
                {
                    el.ImageSource = ImageConverter.ImageSourceFromBitmap(el.Image.Source);
                }
                return adList;
            }
            set
            {
                adList = value;
                foreach (var el in adList)
                {
                    el.ImageSource = ImageConverter.ImageSourceFromBitmap(el.Image.Source);
                }
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
