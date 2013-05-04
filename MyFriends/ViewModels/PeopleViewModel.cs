using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight.Messaging;
using MyFriends.Annotations;
using MyFriends.Messages;
using MyFriends.Services;
using Windows.ApplicationModel.Contacts;

namespace MyFriends.ViewModels
{
    public class PeopleViewModel : INotifyPropertyChanged
    {
        readonly IMessenger _messenger;
        readonly StoreImages _storeImages;

        ObservableCollection<PersonOverViewModel> _items;
        string _title;

        public PeopleViewModel(IMessenger messenger, StoreImages storeImages)
        {
            _messenger = messenger;
            _storeImages = storeImages;
            Items = new ObservableCollection<PersonOverViewModel>
                        {
                            new PersonOverViewModel() {Name = "Albert"}
                        };
            Title = "Personen";

            _messenger.Register<NewPersonMessage>(this, NewPerson);
        }

        async void NewPerson(NewPersonMessage newPersonMessage)
        {
            var cp = new ContactPicker();

            var ci = await cp.PickSingleContactAsync();
            if (ci != null)
            {
                var model = new PersonOverViewModel()
                                {
                                    Name = ci.Name
                                };
                Items.Add(model);
                var stream =await ci.GetThumbnailAsync();
                if (stream != null)
                {
                    await _storeImages.StorePerson(stream, model.Id);
                    model.ImageId = model.Id;
                }
            }
        }


        public ObservableCollection<PersonOverViewModel> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}