using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Definition.Interfaces
{
    public interface IPageService
    {
        void Map(Type pageType, Type viewModelType);

        Page Build(Type pageType, object parameter);

        Object GetBindingContext(Type pageType);
    }
}
