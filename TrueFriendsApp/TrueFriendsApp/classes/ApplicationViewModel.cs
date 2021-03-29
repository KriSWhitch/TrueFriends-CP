using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TrueFriendsApp.classes
{
    class ApplicationViewModel
    {
        private Advert inputAdvert;

        public List<Advert> Adverts { get; set; }
        public Advert InputAdvert
        {
            get { return inputAdvert; }
            set
            {
                inputAdvert = value;
                OnPropertyChanged("InputAdvert");
            }
        }

        public ApplicationViewModel()
        {
            Adverts = Serialization.Deserialize();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
