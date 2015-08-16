using Definition.Enums;
using Definition.Interfaces;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Mobile.Stack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mobile
{
    public class AppLoader : IAppLoader
    {
        private static object _lock = new object();
        private IDictionary<StackEnum, IStack> _stacks = null;
        private StackEnum? _currentStack = null; 

        public AppLoader()
        {
            // Load Navigation Stacks
            InitializeStacks();

            // Load ViewModels
            InitializeViewModels();                       
        }

        /// <summary>
        /// Loads all the navigation stacks
        /// </summary>
        private void InitializeStacks()
        {
            _stacks = new Dictionary<StackEnum, IStack>();
            _stacks.Add(StackEnum.Authentication, new AuthenticationStack());
            _stacks.Add(StackEnum.Main, new MainStack());
        }
        
        /// <summary>
        /// Automatically create and instance of and register any ViewModel found in the namespace
        /// Mobile.ViewModel
        /// </summary>
        private void InitializeViewModels()
        {
            string @namespace = "Mobile.ViewModel";

            var query = from t in typeof(App).GetTypeInfo().Assembly.DefinedTypes
                        where t.IsClass && t.Namespace == @namespace && t.Name != "BaseViewModel"
                        select t;

            foreach (var t in query.ToList())
                SimpleIoc.Default.Register(() => Activator.CreateInstance(t.GetType()), t.ToString());

        }


        /// <summary>
        /// Changes the MainPage of the mobile app to the chosen stack
        /// </summary>
        /// <param name="stack"></param>
        public void LoadStack(StackEnum stack)
        {
            lock (_lock)
            {
                if (stack == _currentStack)
                    return;

                // Unregister all current services
                UnRegisterServices();

                var stackInstance = _stacks[stack];

                // Register Services
                stackInstance.RegisterServices();

                // Change MainPage
                App.Current.MainPage = stackInstance.MainPage;

                _currentStack = stack;
            }
        }
              
        /// <summary>
        /// Unregisters all services registered within this class
        /// </summary>
        private void UnRegisterServices()
        {
            SimpleIoc.Default.Unregister<IExtNavigationService>();
            SimpleIoc.Default.Unregister<IDialogService>();
        }
    }
}
