using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mobile.Model
{
    public class LoginModel: BaseModel
    {

        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAuthenticated { get; set; }
        public async Task Authenticate()
        {
            //TODO: Do call to fake API repository
            IsAuthenticated = true;
        }

    }
}
