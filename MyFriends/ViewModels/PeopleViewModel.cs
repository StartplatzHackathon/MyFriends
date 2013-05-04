using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MyFriends.Annotations;

namespace MyFriends.ViewModels
{
    public class PeopleViewModel : INotifyPropertyChanged
    {
        ObservableCollection<PersonOverViewModel> _items;

        public PeopleViewModel()
        {
            Items = new ObservableCollection<PersonOverViewModel>
                         {
                             new PersonOverViewModel() {Name = "Albert"}
                         };
            Title = "Personen";
        }

        public ObservableCollection<PersonOverViewModel> Items
        {
            get { return _items; }
            set { _items = value; OnPropertyChanged(); }
        }

        public string Title { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}