using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Mobile.ViewModel
{
    public class AboutViewModel: BaseViewModel
    {
         public AboutViewModel(IExtNavigationService navigationService)
            : base(navigationService)
        {
        }
    }
}
