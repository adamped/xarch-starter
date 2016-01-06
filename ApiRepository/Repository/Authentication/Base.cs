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
    public partial class AuthenticationRepository : BaseRepository, IAuthenticationRepository
    {

        public AuthenticationRepository(string baseUrl, string entity) : base(baseUrl, entity)
        {

        }


        

    }
}

