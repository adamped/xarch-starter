using ApiRepository.Repository;
using Common;
using DataService;
using Definition.Enums;
using Definition.Interfaces;
using Definition.Interfaces.Messenger;
using Definition.Interfaces.Repository;
using Definition.Interfaces.Service;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using Mobile.Helper;
using Mobile.Messenger;
using Mobile.Model;
using Mobile.Stack;
using Mobile.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Mobile
{
    public class AppLoader : IAppLoader
    {
        private static AsyncLock _lock = new AsyncLock();
        private IDictionary<StackEnum, IStack> _stacks = null;
        private StackEnum? _currentStack = null;

        public AppLoader()
        {

            // Sequence is important here

            // Load Services
            InitializeServices();

            // Load Navigation Stacks
            InitializeStacks();

            // Load Repositories
            InitializeRepositories();

            // Load Data Services
            InitializeDataServices();

            // Register Repositories for Authorization Header Injection
            RegisterAuthRepositories();

            // Load Messengers
            InitializeMessengers();

            // Load Models
            InitializeModels();

        }

        /// <summary>
        /// Helper function to check if already registered before trying again
        /// </summary>
        private void RegisterOnce<TInterface, TClass>() where TClass : class
                                                        where TInterface : class
        {
            if (!SimpleIoc.Default.IsRegistered<TInterface>())
                SimpleIoc.Default.Register<TInterface, TClass>();
        }

        private void RegisterOnce<TClass>() where TClass : class
        {
            if (!SimpleIoc.Default.IsRegistered<TClass>())
                SimpleIoc.Default.Register<TClass>();
        }

        private void RegisterOnce<T>(Func<T> func) where T : class
        {
            if (!SimpleIoc.Default.IsRegistered<T>())
                SimpleIoc.Default.Register<T>(func);
        }

        private void RegisterAuthRepository<T>() where T : IAuthRepository
        {
            var authorizationService = ServiceLocator.Current.GetInstance<IAuthenticationService>();
            authorizationService.InjectAuthorization(ServiceLocator.Current.GetInstance<T>());
        }

        private void InitializeServices()
        {
            RegisterOnce<IPageService, PageService>();
            RegisterOnce<IExtNavigationService, ExtNavigationService>();
            RegisterOnce<IExtDialogService, DialogService>();
        }

        /// <summary>
        /// Loads all the navigation stacks
        /// </summary>
        private void InitializeStacks()
        {

            RegisterOnce<AuthenticationStack>();
            RegisterOnce<MainStack>();

            _stacks = new Dictionary<StackEnum, IStack>();
            _stacks.Add(StackEnum.Authentication, ServiceLocator.Current.GetInstance<AuthenticationStack>());
            _stacks.Add(StackEnum.Main, ServiceLocator.Current.GetInstance<MainStack>());
        }

        private void InitializeRepositories()
        {
            RegisterOnce<IAuthenticationRepository>(() => new AuthenticationRepository(Config.BaseUrl, ""));
            RegisterOnce<IExampleRepository>(() => new ExampleRepository(Config.BaseUrl, "examples"));
        }

        private void InitializeDataServices()
        {
            RegisterOnce<IAuthenticationService, AuthenticationService>();
            RegisterOnce<IExampleService, ExampleService>();
            
        }

        private void RegisterAuthRepositories()
        {
            RegisterAuthRepository<IExampleRepository>();
        }

        private void InitializeMessengers()
        {
            RegisterOnce<IDefaultMessenger, DefaultMessenger>();
        }

        private void InitializeModels()
        {
            RegisterOnce<LoginModel>();
            RegisterOnce<MainModel>();
            RegisterOnce<AboutModel>();
            RegisterOnce<MenuModel>();
        }


        /// <summary>
        /// Automatically create an instance of and register any ViewModel found in the namespace
        /// Mobile.ViewModel
        /// </summary>
        public void InitializeViewModels()
        {
            string @namespace = "Mobile.ViewModel";

            var query = from t in typeof(App).GetTypeInfo().Assembly.DefinedTypes
                        where t.IsClass && !t.IsSealed && t.Namespace == @namespace && t.Name != "BaseViewModel"
                        select t;

            foreach (var t in query.ToList())
            {
                var defaultConstructor = t.DeclaredConstructors.First();

                object instance = null;

                if (defaultConstructor.GetParameters().Count() == 0)
                    instance = (BaseViewModel)Activator.CreateInstance(t.AsType());
                else
                {
                    List<object> parameters = new List<object>();
                    foreach (var p in defaultConstructor.GetParameters())
                    {
                        parameters.Add(ServiceLocator.Current.GetInstance(p.ParameterType));
                    }

                    instance = (BaseViewModel)Activator.CreateInstance(t.AsType(), parameters.ToArray());
                }

                // Subscribe to all messenger events
                ((BaseViewModel)instance).Subscribe();

                SimpleIoc.Default.Register(() => instance, t.ToString());
            }

        }


        /// <summary>
        /// Changes the MainPage of the mobile app to the chosen stack
        /// </summary>
        /// <param name="stack"></param>
        public async Task LoadStack(StackEnum stack, INavigationArgs navigationArgs = null)
        {
            using (var releaser = await _lock.LockAsync())
            {
                if (stack == _currentStack)
                    return;

                var stackInstance = _stacks[stack];

                // Register Services
                await stackInstance.InitializeServices(navigationArgs);

                // Change MainPage
                App.Current.MainPage = stackInstance.MainPage;

                _currentStack = stack;
            }
        }

    }
}
