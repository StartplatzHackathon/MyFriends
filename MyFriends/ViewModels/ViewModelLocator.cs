﻿using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public StartPageAppBarViewModel StartPageAppBar 
        {
            get 
            {
                return SimpleIoc.Default.GetInstance<StartPageAppBarViewModel>();
            }
        }
    }
}
