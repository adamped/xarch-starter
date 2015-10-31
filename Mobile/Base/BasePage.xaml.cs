using Definition.Interfaces;
using Mobile.ViewModel;
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
            PageInstanceId = Guid.NewGuid();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var bindingContext = BindingContext as BaseViewModel;

            if (bindingContext != null)
                bindingContext.OnAppearing();

        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            var bindingContext = BindingContext as BaseViewModel;

            if (bindingContext != null)
                bindingContext.OnDisappearing();

        }

        public virtual void Cleanup() { }
    }
}
