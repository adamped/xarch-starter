using Mobile.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Interfaces;

namespace Mobile.Helper
{
    public class ExtNavigationPage : NavigationPage
    {

        public ExtNavigationPage(Page content)
            : base(content)
        {
            Init();
        }

        private void Init()
        {
            this.Popped += (object sender, NavigationEventArgs e) =>
            {
                var page = e.Page as ICleanupPage;

                if (page != null)
                    page.Cleanup();

                if (e.Page != null)
                {
                    e.Page.BindingContext = null;
                    if (e.Page.ToolbarItems != null)
                        e.Page.ToolbarItems.Clear();
                }

            };
        }
    }
}
