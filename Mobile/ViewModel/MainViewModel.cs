using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Mobile.ViewModel
{
    public class MainViewModel: BaseViewModel
    {
         public MainViewModel(IExtNavigationService navigationService)
            : base(navigationService)
        {
        }
    }
}
