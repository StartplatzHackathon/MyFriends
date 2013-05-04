using MyFriends.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFriends.ViewModels
{
    public class GiftViewModel : BindableBase
    {
        private String _name, _placeName;

        public String Name 
        {
            get { return _name; }
            set
            {
                SetProperty(ref _name, value);
            }
        }

        public String PlaceName
        {
            get { return _placeName; }
            set
            {
                SetProperty(ref _placeName, value);
            }
        }
    }
}
