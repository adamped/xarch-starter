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

        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _authenticationRepository.Login(email, password);

            // Inject token into authorization headers
            if (result.Success)
                foreach (var repository in _repositories)
                    repository.InjectAuthorizationHeader(result.Value);

            return result.Success;
        }

        private List<IAuthRepository> _repositories = new List<IAuthRepository>();
        public void InjectAuthorization(IAuthRepository authRepository)
        {
            if (!_repositories.Contains(authRepository))
                _repositories.Add(authRepository);
        }
    }
}
