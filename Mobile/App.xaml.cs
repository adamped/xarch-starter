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

		public App()
		{
			InitializeComponent();

            // Set default ServiceLocatorProvider 
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // Navigation Page
            InitializeNavigationPage();

            // Load Services
            InitializeServices();

            // Load ViewModels
            InitializeViewModels();

            // The root page of your application
            MainPage = _navPage;
		}

        private void InitializeNavigationPage()
        {
            _navPage = new ExtNavigationPage(new MainPage());
        }

        private void InitializeServices()
        {
            SimpleIoc.Default.Register<IExtNavigationService>(() => this.CreateNavigationService());
            SimpleIoc.Default.Register<IDialogService>(() => new DialogService());
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

        private IExtNavigationService CreateNavigationService()
        {
            return new ExtNavigationService();
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
