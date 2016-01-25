using Definition.Interfaces;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Mobile.Helper;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile.Stack
{
    public class BaseStack
    {
        public Page MainPage { get; protected set; }
        public NavigationPage NavigationPage { get; protected set; }

        protected IExtNavigationService _navigationService = null;
        private IExtDialogService _dialogService = null;
        protected IPageService _pageService = null;

        private bool _isFirstRun = false;

        public BaseStack(IExtNavigationService navigationService, IExtDialogService dialogService, IPageService pageService)
        {
            _navigationService = navigationService;
            _dialogService = dialogService;
            _pageService = pageService;
        }

        /// <summary>
        /// Will register appropriate Services for Dependency Injection.
        /// </summary>
        public async Task InitializeServices(INavigationArgs navigationArgs = null)
        {

            _navigationService.Init(NavigationPage);
            _dialogService.Init(NavigationPage);

            if (!_isFirstRun)
            {
                MapPages();
                MapViewModels();

                await _navigationService.NavigateTo(NavigationStartPageKey, navigationArgs);

                _isFirstRun = true;
            }

        }

        protected virtual void MapPages() { }
        protected virtual void MapViewModels() { }
        protected virtual string NavigationStartPageKey { get; }
        
    }
}
