using Definition.Enums;
using Definition.Interfaces;
using Definition.Interfaces.Messenger;
using GalaSoft.MvvmLight.Command;
using Mobile.Helper;
using Mobile.Model;
using System;

namespace Mobile.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {

        private IAppLoader _appLoader = null;
        private IDefaultMessenger _defaultMessenger = null;

        public LoginViewModel(IAppLoader appLoader, LoginModel loginModel, IDefaultMessenger defaultMessenger) : base(defaultMessenger)
        {
            _appLoader = appLoader;
            _defaultMessenger = defaultMessenger;

            Model = loginModel;
        }

        private LoginModel _model = null;
        public LoginModel Model
        {
            get
            {
                return _model;
            }
            set
            {
                if (value != _model)
                {
                    _model = value;
                    RaisePropertyChanged(() => Model);
                }
            }
        }

        private RelayCommand _loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                return _loginCommand
                       ?? (_loginCommand = new RelayCommand(
                           async () =>
                           {
                               await _loginCommand.SingleRun(async () =>
                               {
                                   try
                                   {
                                       IsBusy = true;

                                       await Model.Authenticate();

                                       if (Model.IsAuthenticated)
                                       {
                                           _defaultMessenger.SendNotification("Sent from LoginViewModel", Token.LoggedIn);
                                           await _appLoader.LoadStack(StackEnum.Main);
                                       }
                                       else
                                       {
                                           await DialogService.ShowMessage("The login details provided were incorrect. Please try again.", "Login Error");
                                       }
                                   }
                                   finally
                                   {
                                       IsBusy = false;
                                   }

                               });

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
