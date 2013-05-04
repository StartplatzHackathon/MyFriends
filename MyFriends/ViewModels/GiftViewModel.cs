using MyFriends.Common;
using MyFriends.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MyFriends.ViewModels
{
    public class GiftViewModel : INotifyPropertyChanged
    {
        private Gift _gift;

        public GiftViewModel()
        {
            _gift = new Gift();
        }

        public String Name 
        {
            get { return _gift.Name; }
            set
            {
                _gift.Name = value;
                OnPropertyChanged();
            }
        }

        public String PlaceName
        {
            get { return _gift.PlaceName; }
            set
            {
                _gift.PlaceName = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
