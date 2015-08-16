using Common;
using Definition.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace Mobile.ViewModel
{
    public class BaseViewModel : ViewModelBase
    {
        protected AsyncLock _lock = new AsyncLock();

        protected IExtNavigationService NavigationService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IExtNavigationService>();
            }
        }

        protected IDialogService DialogService
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IDialogService>();
            }
        }

    }
}
