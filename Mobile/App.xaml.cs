using GalaSoft.MvvmLight.Ioc;
using Mobile.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Mobile.View;
using Definition.Enums;
using Microsoft.Practices.ServiceLocation;
using GalaSoft.MvvmLight.Views;

using Definition.Interfaces;

namespace Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
         
            // Set default ServiceLocatorProvider 
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            // Initialize Services and Stack
            var appLoader = new AppLoader();            
            SimpleIoc.Default.Register<IAppLoader>(() => appLoader);
            appLoader.InitializeViewModels();
           
            // Load initial navigation stack
            ServiceLocator.Current.GetInstance<IAppLoader>().LoadStack(StackEnum.Authentication).Wait();

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
