using Definition.Interfaces;
using GalaSoft.MvvmLight.Views;
using Mobile.Model;
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
    public class MainStack : BaseStack, IStack
    {

        private Main _locator = new Main();

        public MainStack(IExtNavigationService navigationService, IExtDialogService dialogService, IPageService pageService): base(navigationService, dialogService, pageService)
        {
            NavigationPage = new NavigationPage();

            MainPage = new MasterDetailPage()
            {
                BackgroundColor = Color.Transparent,
                Master = BuildMenuPage(),
                Detail = NavigationPage
            };
        }

        private Page BuildMenuPage()
        {
            return new MenuPage()
            {             
                Title = "Menu",
                Icon = "icon.png",  //TODO: add in default icon 
                BindingContext = new MenuViewModel(null, null, null, null) 
            };
        }

        protected override void MapPages()
        {
            _navigationService.Map(_locator.MainPage, typeof(MainPage));
            _navigationService.Map(_locator.AboutPage, typeof(AboutPage));
        }

        protected override void MapViewModels()
        {
            _pageService.Map(typeof(MainPage), typeof(MainViewModel));
            _pageService.Map(typeof(AboutPage), typeof(AboutViewModel));
        }

        protected override string NavigationStartPageKey
        {
            get
            {
                return _locator.MainPage;
            }
        }
    }
}
