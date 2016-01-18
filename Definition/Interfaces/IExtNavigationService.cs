using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definition.Interfaces
{
    public interface IExtNavigationService
    {
        Task NavigateTo(string pageKey);

        Task NavigateTo(string pageKey, INavigationArgs navigationArgs);

        bool CanGoBack();

        Task GoBack();

        void Map(string pageKey, Type pageType);
       
    }
}
