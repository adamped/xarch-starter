using Definition.Interfaces.Repository;
using Definition.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataService
{
    /// <summary>
    /// Will be used to authenticate with the API. This example uses REST and JWT
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        IAuthenticationRepository _authenticationRepository;
        public AuthenticationService(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        private static string Token = "";

        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _authenticationRepository.Login(email, password);

            return result.Success;
        }

    }
}
