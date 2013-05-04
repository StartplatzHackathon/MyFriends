using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyFriends.Services;

namespace MyFriends.ViewModels
{
    public class ViewModelLocator
    {
        private static ViewModelLocator _current;

        public static ViewModelLocator Current
        {
            get
            {
                if (_current == null)
                {
                    _current = new ViewModelLocator();
                }

                return _current;
            }
        }

        public ViewModelLocator()
        {
            _current = this;

            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IMessenger>(() => Messenger.Default);
            SimpleIoc.Default.Register<StartPageAppBarViewModel>();
            SimpleIoc.Default.Register<StoreImages>();
            SimpleIoc.Default.Register<LoadImages>();

            SimpleIoc.Default.Register<PeopleViewModel>(true);

        }

        public StartPageAppBarViewModel StartPageAppBar 
        {
            get 
            {
                return SimpleIoc.Default.GetInstance<StartPageAppBarViewModel>();
            }
        }

        public PeopleViewModel PeopleViewModel
        {
            get { return SimpleIoc.Default.GetInstance<PeopleViewModel>(); }
        }
    }
}
