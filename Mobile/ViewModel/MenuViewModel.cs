using Definition.Interfaces;
using Definition.Interfaces.Messenger;
using GalaSoft.MvvmLight.Views;
using Mobile.Model;

namespace Mobile.ViewModel
{
    public class MenuViewModel : BaseViewModel
    {
        public MenuViewModel(MenuModel model, IDefaultMessenger defaultMessenger,
                             IExtNavigationService navigationService, IDialogService dialogService)
             : base(defaultMessenger, model, navigationService, dialogService)
        { }

    }
}
