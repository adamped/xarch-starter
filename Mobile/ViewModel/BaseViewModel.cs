using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Interfaces;

namespace Mobile.ViewModel
{
    public class BaseViewModel : ViewModelBase
    {
        protected AsyncLock _lock = new AsyncLock();
        protected IExtNavigationService _navigationService = null;
        public BaseViewModel(IExtNavigationService navigationService)
        {
            _navigationService = navigationService;
        }
    }
}
