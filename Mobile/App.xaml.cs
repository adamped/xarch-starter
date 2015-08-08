using GalaSoft.MvvmLight.Ioc;
using Mobile.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Interfaces;
using Mobile.View;
using Mobile.Helper;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Views;
using System.Reflection;

namespace Mobile
{
    public partial class App : Application
    {
        private static NavigationPage _navPage = null;
        private static MasterDetailPage _masterDetailPage = null;
        private static object _lock = new object();

        public App()
        {
            InitializeComponent();

            // Set default ServiceLocatorProvider 
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // Load ViewModels
            InitializeViewModels();

            // Load initial navigation stack
            LoadStack(Stack.Authentication);

        }

        private void InitializeNavigationPage(Page page)
        {
            _navPage = new ExtNavigationPage(page);
        }

        private void InitializeMasterDetailPage(Page detailPage)
        {
            _masterDetailPage = new MasterDetailPage()
            {
                BackgroundColor = Color.Transparent,
                Master = new MenuPage() { Title = "Menu", Icon = "todo: insert hamburger image" },
                Detail = detailPage
            };
        }

        private void InitializeServices(NavigationPage page)
        {
            SimpleIoc.Default.Register<IExtNavigationService>(() => this.CreateNavigationService(page));
            SimpleIoc.Default.Register<IDialogService>(() => new DialogService(page));
        }

        private void UnRegisterServices()
        {
            SimpleIoc.Default.Unregister<IExtNavigationService>();
            SimpleIoc.Default.Unregister<IDialogService>();
        }

        private void InitializeViewModels()
        {
            string @namespace = "Mobile.ViewModel";

            var query = from t in typeof(App).GetTypeInfo().Assembly.DefinedTypes
                        where t.IsClass && t.Namespace == @namespace && t.Name != "BaseViewModel"
                        select t;

            foreach (var t in query.ToList())
                SimpleIoc.Default.Register(() => Activator.CreateInstance(t.GetType()), t.ToString());

        }

        private IExtNavigationService CreateNavigationService(NavigationPage page)
        {
            return new ExtNavigationService(page);
        }

        public void LoadStack(Stack stack)
        {
            lock (_lock)
            {
                UnRegisterServices();

                switch (stack)
                {                   
                    case Stack.Main:                        
                        InitializeNavigationPage(new MainPage());
                        InitializeMasterDetailPage(_navPage);
                        InitializeServices(_navPage);
                        MainPage = _masterDetailPage;
                        break;
                    case Stack.Authentication:
                    default:
                        InitializeNavigationPage(new LoginPage());
                        InitializeServices(_navPage);
                        MainPage = _navPage;
                        break;
                }
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
