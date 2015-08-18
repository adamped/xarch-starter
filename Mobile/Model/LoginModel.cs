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

        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAuthenticated { get; set; }
        public async Task Authenticate()
        {         
           IsAuthenticated = await _authenticationService.Authenticate(Email, Password);
        }

    }
}
