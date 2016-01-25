using Definition.Interfaces;
using GalaSoft.MvvmLight.Views;
using Mobile.PageLocator;
using Mobile.View;
using Mobile.ViewModel;
using Xamarin.Forms;

namespace Mobile.Stack
{
    public class AuthenticationStack : BaseStack, IStack
    {

        private Authentication _locator = new Authentication();

        public AuthenticationStack(IExtNavigationService navigationService, IExtDialogService dialogService, IPageService pageService) : base(navigationService, dialogService, pageService)
        {
            var navPage = new NavigationPage();

            // Disable NavigationBar on all pages within this Stack.
            navPage.Pushed += (s, e) => { NavigationPage.SetHasNavigationBar(e.Page, false); };
            
            MainPage = NavigationPage = navPage;
        }

        protected override void MapPages()
        {
            _navigationService.Map(_locator.LoginPage, typeof(LoginPage));
        }

        protected override void MapViewModels()
        {
            _pageService.Map(typeof(LoginPage), typeof(LoginViewModel));
        }

        protected override string NavigationStartPageKey
        {
            get
            {
                return _locator.LoginPage;
            }
        }

    }
}
