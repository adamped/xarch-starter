using Definition.Enums;
using Definition.Interfaces;
using GalaSoft.MvvmLight.Command;
using Mobile.Model;

namespace Mobile.ViewModel
{
    public class LoginViewModel: BaseViewModel
    {

        private IAppLoader _appLoader = null;

        public LoginViewModel(IAppLoader appLoader)
        {
            _appLoader = appLoader;

            Login = new LoginModel();
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
                                       _appLoader.LoadStack(StackEnum.Main);
                                   }
                               }                               

                           }));
            }
        }


    }
}
