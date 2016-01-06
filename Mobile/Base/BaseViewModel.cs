using Common;
using Definition.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile.ViewModel
{
    public class BaseViewModel : ViewModelBase
    {
        protected AsyncLock _lock = new AsyncLock();

        public BaseViewModel() { }

        public BaseViewModel(GalaSoft.MvvmLight.Messaging.IMessenger messenger) : base(messenger) { }

        public virtual void Subscribe() { }

        public virtual void OnAppearing() { }

        public virtual void OnDisappearing() { }

        public virtual void OnBackButtonPressed() { }

        public virtual void OnPopped(Page page) { }

        public virtual Task OnNavigated(object parameter) { return Task.Run(() => { }); }

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

        private bool _isBusy = false;
        public bool IsBusy { get { return _isBusy; } set { _isBusy = value; RaisePropertyChanged(); } }

        private static bool _running = false;
        protected AsyncLock _runLock = new AsyncLock();

        public async Task SingleRun(Task<Action> operation)
        {

            try
            {
                using (var releaser = await _runLock.LockAsync())
                {

                    if (_running)
                        return;
                    else
                        _running = true;
                }

                IsBusy = true;

                await operation;

                IsBusy = false;

                _running = false;

            }
            catch (Exception ex)
            {
                // TODO: Need to add Error Reporting (e.g. Insights or RayGun) right here
            }

        }

    }
}
