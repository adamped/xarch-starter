using Definition.Interfaces;
using Definition.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Model
{
    public class LoginModel: BaseModel
    {
        IAuthenticationService _authenticationService;

        public LoginModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        private string _email = "";
        public string Email { get { return _email; } set { _email = value; RaisePropertyChanged(() => Email); } }

        private string _password = "";
        public string Password { get { return _password; } set { _password = value; RaisePropertyChanged(() => Password); } }

        public bool IsAuthenticated { get; set; }
        public async Task Authenticate()
        {         
           IsAuthenticated = await _authenticationService.Authenticate(Email, Password);
        }

    }
}
