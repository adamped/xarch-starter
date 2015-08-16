using Definition.Interfaces;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Mobile.Helper;
using Mobile.PageLocator;
using Mobile.View;
using Mobile.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }
}
