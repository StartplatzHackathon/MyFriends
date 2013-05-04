using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MyFriends.Properties;

namespace MyFriends.ViewModels
{
    public class PersonOverViewModel : INotifyPropertyChanged
    {
        public PersonOverViewModel()
        {
            Id = Guid.NewGuid();
        }
        string _name;
        Guid _imageId;

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public Guid ImageId
        {
            get { return _imageId; }
            set
            {
                if (Equals(value, _imageId)) return;
                _imageId = value;
                OnPropertyChanged();
            }
        }

        public Guid Id { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}