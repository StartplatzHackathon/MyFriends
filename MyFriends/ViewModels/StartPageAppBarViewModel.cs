using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MyFriends.Common;
using MyFriends.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFriends.Messages;

namespace MyFriends.ViewModels
{
    public class StartPageAppBarViewModel : BindableBase
    {
        public RelayCommand NewGiftCommand
        {
            get;
            private set;
        }

        public RelayCommand ShowPeopleCommand { private set; get; }

        public StartPageAppBarViewModel()
        {
            NewGiftCommand = new RelayCommand(NewGift);
            ShowPeopleCommand = new RelayCommand(ShowPeople);
            NewPersonCommand = new RelayCommand(NewPerson);
        }

        void NewPerson()
        {
            Messenger.Default.Send<NewPersonMessage>(new NewPersonMessage());
        }

        protected RelayCommand NewPersonCommand { get; private set; }

        void ShowPeople()
        {
            Messenger.Default.Send<Guid>(Guid.Empty,NavigationTokens.PeopleOverview);
        }

        private void NewGift()
        {
            Messenger.Default.Send<Guid>(Guid.Empty, NavigationTokens.EditGift);
        }
    }
}
