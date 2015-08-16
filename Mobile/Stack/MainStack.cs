using Definition.Interfaces;
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
    public class MainStack: BaseStack, IStack
    {

        private Main _locator = new Main();

        public MainStack()
        {
            NavigationPage = new NavigationPage();

            MainPage = new MasterDetailPage()
            {
                BackgroundColor = Color.Transparent,
                //Master = new MenuPage() { Title = "Menu", Icon = "todo: insert hamburger image" },
                Detail = NavigationPage
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
    }
}
