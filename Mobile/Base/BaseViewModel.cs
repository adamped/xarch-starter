using Common;
using Definition.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Mobile.Model;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile.ViewModel
{
    public class BaseViewModel : ViewModelBase
    {
        protected AsyncLock _lock = new AsyncLock();
        private readonly BaseModel _model = null;

        public BaseViewModel(GalaSoft.MvvmLight.Messaging.IMessenger messenger, BaseModel model, IExtNavigationService navigationService, IDialogService dialogService) : base(messenger)
        {
            _model = model;
            NavigationService = navigationService;
            DialogService = dialogService;
        }

        protected IExtNavigationService NavigationService { get; private set; }

        protected IDialogService DialogService { get; private set; }

        public virtual void Subscribe() { }

        public virtual void OnAppearing() { }

        public virtual void OnDisappearing() { }

        public virtual void OnBackButtonPressed() { }

        public virtual void OnPopped(Page page) { }

        public virtual Task OnNavigated(object parameter) { return Task.Run(() => { }); }
        
        private bool _isBusy = false;
        public bool IsBusy { get { return _isBusy; } set { _isBusy = value; RaisePropertyChanged(); } }


    }
}
