using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Definition.Interfaces;
using GalaSoft.MvvmLight.Views;
using Mobile.Model;
using Definition.Interfaces.Messenger;

namespace Mobile.ViewModel
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel(AboutModel model, IDefaultMessenger defaultMessenger, 
                              IExtNavigationService navigationService, IDialogService dialogService) 
             : base(defaultMessenger, model, navigationService, dialogService)
        { }

    }
}
