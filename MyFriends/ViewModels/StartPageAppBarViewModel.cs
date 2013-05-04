using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MyFriends.Common;
using System;
using MyFriends.Messages;

namespace MyFriends.ViewModels
{
    public  sealed class StartPageAppBarViewModel : BindableBase
    {
        readonly IMessenger _messenger;

        public RelayCommand NewGiftCommand { get; private set; }
        public RelayCommand NewPersonCommand { get; private set; }
        public RelayCommand ShowPeopleCommand { get; private set; }

        public StartPageAppBarViewModel(IMessenger messenger)
        {
            _messenger = messenger;
            NewGiftCommand = new RelayCommand(NewGift);
            ShowPeopleCommand = new RelayCommand(ShowPeople);
            NewPersonCommand = new RelayCommand(NewPerson);
        }

        void NewPerson()
        {
            _messenger.Send<NewPersonMessage>(new NewPersonMessage());
        }

        void ShowPeople()
        {
            _messenger.Send<Guid>(Guid.Empty, NavigationTokens.PeopleOverview);
        }

        void NewGift()
        {
            _messenger.Send<Guid>(Guid.Empty, NavigationTokens.EditGift);
        }
    }
}