using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFriends.DataModel;

namespace MyFriends.ViewModels
{
    public class PeopleViewModel
    {
        ObservableCollection<Person> People { get; set; }
    }
}
