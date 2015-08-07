using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile.View
{
    public partial class BasePage : ContentPage, ICleanupPage
    {

        public Guid PageInstanceId { get; set; }

        public BasePage()
        {
            InitializeComponent();
        }

        public virtual void Cleanup()
        {
            
        }
    }
}
