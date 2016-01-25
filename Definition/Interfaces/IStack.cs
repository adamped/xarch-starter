using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Definition.Interfaces
{
   public interface IStack
    {
        //REVIEW: I don't like the Xamarin.Forms dependency in this project.
        Page MainPage { get; }

        NavigationPage NavigationPage { get; }

        Task InitializeServices(INavigationArgs navigationArgs = null);
    }
}
