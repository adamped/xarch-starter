using Definition.Enums;
using Definition.Interfaces;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Mobile.Styles;
using System.Reflection;
using Xamarin.Forms;

namespace Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            App.Current.MainPage = new ContentPage(); // Needs a page even if empty for the moment for iOS

            // Set default ServiceLocatorProvider 
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (Device.OS == TargetPlatform.Windows) // Due to bug: https://bugzilla.xamarin.com/show_bug.cgi?id=36730 (remove this code once bug fixed)
                Device.BeginInvokeOnMainThread(() => { OnStart(); });

        }

        protected async override void OnStart()
        {
            // Initialize Services and Stack
            var appLoader = new AppLoader();
            SimpleIoc.Default.Register<IAppLoader>(() => appLoader);
            appLoader.InitializeViewModels();

            // Load initial navigation stack
            await ServiceLocator.Current.GetInstance<IAppLoader>().LoadStack(StackEnum.Authentication);
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
