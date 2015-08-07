using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using System.Reflection;
using Xamarin.Forms;
using Mobile.View;
using Common;

namespace Mobile.Helper
{
    public class ExtNavigationService : IExtNavigationService
    {
        private readonly Dictionary<string, Type> _pagesByKey = new Dictionary<string, Type>();
        private NavigationPage _navigation;
        private static AsyncLock _lock = new AsyncLock();

        public string CurrentPageKey
        {
            get
            {
                lock (_pagesByKey)
                {
                    if (_navigation.CurrentPage == null)
                    {
                        return null;
                    }

                    var pageType = _navigation.CurrentPage.GetType();

                    return _pagesByKey.ContainsValue(pageType)
                        ? _pagesByKey.First(p => p.Value == pageType).Key
                        : null;
                }
            }
        }

        public async Task NavigateTo(string pageKey, object parameter)
        {
            await NavigateTo(pageKey, parameter, true);
        }

        private async Task NavigateTo(string pageKey, object parameter, bool animated)
        {
            using (var releaser = await _lock.LockAsync())
            {
                if (_pagesByKey.ContainsKey(pageKey))
                {
                    var type = _pagesByKey[pageKey];
                    ConstructorInfo constructor = null;
                    object[] parameters = null;

                    if (parameter == null)
                    {
                        constructor = type.GetTypeInfo()
                            .DeclaredConstructors
                            .FirstOrDefault(c => !c.GetParameters().Any());

                        parameters = new object[] { };
                    }
                    else
                    {
                        constructor = type.GetTypeInfo()
                            .DeclaredConstructors
                            .FirstOrDefault(
                                c =>
                                {
                                    var p = c.GetParameters();
                                    return p.Count() == 1
                                           && p[0].ParameterType == parameter.GetType();
                                });

                        parameters = new[]
                                    {
                                        parameter
                                    };
                    }

                    if (constructor == null)
                        throw new InvalidOperationException(
                            "No suitable constructor found for page " + pageKey);

                    var page = constructor.Invoke(parameters) as Page;

                    var basePage = page as BasePage;

                    // Assigns a unique Id to the page.
                    if (basePage != null)
                        basePage.PageInstanceId = Guid.NewGuid();

                    await _navigation.PushAsync(page, animated);
                }
                else
                {
                    throw new ArgumentException(
                        string.Format(
                            "No such page: {0}. Did you forget to call NavigationService.Configure?",
                            pageKey),
                        "pageKey");
                }
            }
        }

        public void Configure(string pageKey, Type pageType)
        {
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(pageKey))
                {
                    _pagesByKey[pageKey] = pageType;
                }
                else
                {
                    _pagesByKey.Add(pageKey, pageType);
                }
            }
        }

        public void Initialize(NavigationPage navigation)
        {
            _navigation = navigation;
        }

        public bool CanGoBack()
        {
            return _navigation.Navigation.NavigationStack.Count > 1;
        }

        public async Task GoBack()
        {
            using (var releaser = await _lock.LockAsync())
            {
                await _navigation.PopAsync();
            }
        }

    }
}
