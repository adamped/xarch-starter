using Definition.Interfaces;
using Mobile.PageLocator;
using Mobile.View;
using Mobile.ViewModel;
using Xamarin.Forms;

namespace Mobile.Stack
{
    public class AuthenticationStack : BaseStack, IStack
    {

        private Authentication _locator = new Authentication();

        public AuthenticationStack()
        {
            MainPage = NavigationPage = new NavigationPage();          
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
