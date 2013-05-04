using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MyFriends.Common;
using MyFriends.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFriends.ViewModels
{
    public class StartPageAppBarViewModel : BindableBase
    {
        private IMessenger _messenger;

        public RelayCommand NewGiftCommand
        {
            get;
            private set;
        }

        public RelayCommand ShowPeopleCommand { private set; get; }

        public StartPageAppBarViewModel(IMessenger messenger)
        {
            _messenger = messenger;

            NewGiftCommand = new RelayCommand(() => NewGift());
            ShowPeopleCommand = new RelayCommand(() => ShowPeople());
        }

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
