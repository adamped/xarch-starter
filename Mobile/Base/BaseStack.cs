using Definition.Interfaces;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Mobile.Helper;
using Xamarin.Forms;

namespace Mobile.Stack
{
    public class BaseStack
    {
        public Page MainPage { get; protected set; }
        public NavigationPage NavigationPage { get; protected set; }

        protected IExtNavigationService _navigationService = null;
        private IDialogService _dialogService = null;
        protected IPageService _pageService = null;

        private bool _isMapped = false;

        /// <summary>
        /// Will register appropriate Services for Dependency Injection.
        /// </summary>
        public void RegisterServices()
        {
            if (_pageService == null)
                _pageService = new PageService();

            if (_navigationService == null)
                _navigationService = new ExtNavigationService(NavigationPage, _pageService);

            SimpleIoc.Default.Register<IExtNavigationService>(() => _navigationService);

            if (_dialogService == null)
                _dialogService = new DialogService(NavigationPage);

            SimpleIoc.Default.Register<IDialogService>(() => _dialogService);

            if (!_isMapped)
            {
                MapPages();
                MapViewModels();

                _isMapped = true;
            }

        }

        protected virtual void MapPages() { }
        protected virtual void MapViewModels() { }
    }
}
