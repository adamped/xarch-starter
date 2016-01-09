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

        public string StyleSheet { get; set; }

        public Guid PageInstanceId { get; set; }

        public BasePage()
        {
            InitializeComponent();
            PageInstanceId = Guid.NewGuid();                
        }

        private bool _initialView = true;

        protected void LoadStyles()
        {

            if (!_initialView)
                return;

            _initialView = false;

            if (!String.IsNullOrEmpty(this.StyleSheet))
            {
                try
                {
                    var stylesheet = Activator.CreateInstance(Type.GetType(this.StyleSheet)) as VisualElement;
                    
                    foreach (var resource in stylesheet.Resources)
                        this.Resources.Add(resource.Key, resource.Value);

                }
                catch
                {
                    // Failed to add stylesheet
                }
            }
        }

        protected override bool OnBackButtonPressed()
        {
            var bindingContext = BindingContext as BaseViewModel;

            if (bindingContext != null)
                bindingContext.OnBackButtonPressed();

            return base.OnBackButtonPressed();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var bindingContext = BindingContext as BaseViewModel;

            if (bindingContext != null)
                bindingContext.OnAppearing();

            LoadStyles();

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
