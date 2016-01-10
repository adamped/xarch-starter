using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.UITest;

namespace Mobile.UITest.Screen
{
    public class Login
    {

        IApp _app = null;
        public Login(IApp app)
        {
            _app = app;
        }

        public string GetEmailText()
        {
            return _app.Query(m => m.Marked("EmailEntry")).FirstOrDefault()?.Text;
        }

    }
}
