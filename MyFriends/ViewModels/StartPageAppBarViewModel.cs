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
        public RelayCommand NewGiftCommand
        {
            get;
            private set;
        }

        public StartPageAppBarViewModel()
        {
            NewGiftCommand = new RelayCommand(() => NewGift());
        }

        private void NewGift()
        {
            Messenger.Default.Send<Guid>(Guid.Empty, MessageTokens.Navigation);
        }
    }
}
