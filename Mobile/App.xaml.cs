using Mobile.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

            // The root page of your application
            MainPage = new ExtNavigationPage(new MainPage());
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
