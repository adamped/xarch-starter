using Definition.Enums;
using Definition.Interfaces;
using Definition.Interfaces.Messenger;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Mobile.Model;

namespace Mobile.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private IDefaultMessenger _defaultMessenger = null;

        public MainViewModel(MainModel model, IDefaultMessenger defaultMessenger, 
                             IExtNavigationService navigationService, IExtDialogService dialogService) 
             : base(defaultMessenger, model, navigationService, dialogService)
        {
            _defaultMessenger = defaultMessenger;

            Model = model;
        }


        public override void Subscribe()
        {
            _defaultMessenger.RegisterNotification<string>(this, Token.LoggedIn, ReceiveNotification);
        }

        private void ReceiveNotification(string message)
        {
            Message = message;
        }

        private string _message = "Default Message";
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                _message = value;
                RaisePropertyChanged(() => Message);
            }
        }

        private MainModel _mainModel = null;
        public MainModel Model
        {
            get
            {
                return _mainModel;
            }
            set
            {
                if (value != _mainModel)
                {
                    _mainModel = value;
                    RaisePropertyChanged(() => Model);
                }
            }
        }

        private RelayCommand _aboutCommand;
        public RelayCommand AboutCommand
        {
            get
            {
                return _aboutCommand
                       ?? (_aboutCommand = new RelayCommand(
                           async () =>
                           {
                               using (var releaser = await _lock.LockAsync())
                               {

                               }

                           }));
            }
        }

        public override void Cleanup()
        {
            base.Cleanup();

            _defaultMessenger.Unregister(this);
        }
    }
}
