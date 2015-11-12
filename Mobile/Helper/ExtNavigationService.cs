// Copyright: Based upon sample code provided by MVVMLight

using Common;
using Definition.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile.Helper
{
    public class ExtNavigationService : IExtNavigationService
    {
        private readonly Dictionary<string, Type> _pagesByKey = new Dictionary<string, Type>();
        private NavigationPage _navigation;
        private IPageService _pageService;
        private static AsyncLock _lock = new AsyncLock();

        public ExtNavigationService(NavigationPage navigation, IPageService pageService)
        {
            _navigation = navigation;
            _pageService = pageService;
        }

        public string CurrentPageKey
        {
            get
            {
                lock (_pagesByKey)
                {
                    if (_navigation.CurrentPage == null)
                        return null;

                    var pageType = _navigation.CurrentPage.GetType();

                    return _pagesByKey.ContainsValue(pageType)
                        ? _pagesByKey.First(p => p.Value == pageType).Key
                        : null;
                }
            }
        }

        public async Task NavigateTo(string pageKey)
        {
            await NavigateTo(pageKey, null);
        }

        public async Task NavigateTo(string pageKey, object parameter)
        {
            await NavigateTo(pageKey, parameter, true);
        }

        private async Task NavigateTo(string pageKey, object parameter, bool animated)
        {
            using (var releaser = await _lock.LockAsync())
            {
                // Do not navigate to the same page.
                if (pageKey == CurrentPageKey)
                    return;

                if (_pagesByKey.ContainsKey(pageKey))
                {
                    var type = _pagesByKey[pageKey];

                    var page = _pageService.Build(type, parameter);

                    if (page == null)
                        throw new Exception(String.Format("Unable to build page {0}", type.ToString()));
                    
                    var tabbedPage = page as TabbedPage;
                    if (tabbedPage != null)
                        foreach (var child in tabbedPage.Children)
                            child.BindingContext = _pageService.GetBindingContext(child.GetType());

                    await _navigation.PushAsync(page, animated);
                }
                else
                {
                    throw new ArgumentException(
                        string.Format(
                            "No such page: {0}. Did you forget to call NavigationService.Map?",
                            pageKey),
                        "pageKey");
                }
            }
        }

        public void Map(string pageKey, Type pageType)
        {
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(pageKey))
                    _pagesByKey[pageKey] = pageType;
                else
                    _pagesByKey.Add(pageKey, pageType);
            }
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
