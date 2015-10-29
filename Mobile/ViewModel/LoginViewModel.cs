using Definition.Enums;
using Definition.Interfaces;
using Definition.Interfaces.Messenger;
using GalaSoft.MvvmLight.Command;
using Mobile.Model;
using System;

namespace Mobile.ViewModel
{
    public class LoginViewModel: BaseViewModel
    {

        private IAppLoader _appLoader = null;
        private IDefaultMessenger _defaultMessenger = null;

        public LoginViewModel(IAppLoader appLoader, LoginModel loginModel, IDefaultMessenger defaultMessenger): base(defaultMessenger)
        {
            _appLoader = appLoader;
            _defaultMessenger = defaultMessenger;

            Login = loginModel;
        }

        private LoginModel _login = null;
        public LoginModel Login
        {
            get
            {
                return _login;
            }
            set
            {
                if (value != _login)
                {
                    _login = value;
                    RaisePropertyChanged(() => Login);
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
                               using (var releaser = await _lock.LockAsync())
                               {
                                   await Login.Authenticate();

                                   if (Login.IsAuthenticated)
                                   {
                                       _defaultMessenger.SendNotification("Sent from LoginViewModel", Token.LoggedIn);
                                       await _appLoader.LoadStack(StackEnum.Main);
                                   }
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
