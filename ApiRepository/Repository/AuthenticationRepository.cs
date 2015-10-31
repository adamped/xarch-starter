using Definition.Interfaces.Repository;
using Definition.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ApiRepository.Repository
{
    public class AuthenticationRepository : BaseRepository, IAuthenticationRepository
    {

        public AuthenticationRepository(string baseUrl)
        {
            _client.DefaultRequestHeaders
                              .Accept
                              .Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _client.BaseAddress = new Uri(baseUrl);
        }


        public async Task<Result<string>> Login(string email, string password)
        {

            // Fake API Call Delay
            await Task.Delay(500);

            if (email == "demo" && password == "demo")
                // Return fake results. Use POST to make an actual API call
                return new Result<string>()
                {
                    Success = true,
                    Value = "ExampleToken"
                };
            else
                return new Result<string>() { Success = false };


        }

    }
}

