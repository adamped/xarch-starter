using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Definition.Interfaces
{
    public interface IExtNavigationService
    {
        void Init(NavigationPage navigation);

        Task NavigateTo(string pageKey);

        Task NavigateTo(string pageKey, INavigationArgs navigationArgs);

        bool CanGoBack();

        Task GoBack();

        void Map(string pageKey, Type pageType);
       
    }
}
