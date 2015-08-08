using GalaSoft.MvvmLight.Command;
using Mobile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Mobile.ViewModel
{
    public class LoginViewModel: BaseViewModel
    {

        public LoginViewModel(IExtNavigationService navigationService): base(navigationService)
        {
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
                                       
                                   }
                               }                               

                           }));
            }
        }


    }
}
