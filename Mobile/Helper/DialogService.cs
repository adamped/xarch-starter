// Copyright: Based upon sample code provided by MVVMLight

using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile.Helper
{
    public class DialogService : IDialogService
    {
        private Page _dialogPage;
        public async Task ShowError(string message,
    string title,
    string buttonText,
    Action afterHideCallback)
        {
            if (_dialogPage != null)
                await _dialogPage.DisplayAlert(
                    title,
                    message,
                    buttonText);

            if (afterHideCallback != null)
            {
                afterHideCallback();
            }
        }

        public async Task ShowError(
            Exception error,
            string title,
            string buttonText,
            Action afterHideCallback)
        {
            if (_dialogPage != null)
                await _dialogPage.DisplayAlert(
                    title,
                    error.Message,
                    buttonText);

            if (afterHideCallback != null)
            {
                afterHideCallback();
            }
        }

        public async Task ShowMessage(
            string message,
            string title)
        {
            if (_dialogPage != null)
                await _dialogPage.DisplayAlert(
                    title,
                    message,
                    "OK");
        }

        public async Task ShowMessage(
            string message,
            string title,
            string buttonText,
            Action afterHideCallback)
        {
            if (_dialogPage != null)
                await _dialogPage.DisplayAlert(
                    title,
                    message,
                    buttonText);

            if (afterHideCallback != null)
            {
                afterHideCallback();
            }
        }

        public async Task<bool> ShowMessage(
            string message,
            string title,
            string buttonConfirmText,
            string buttonCancelText,
            Action<bool> afterHideCallback)
        {
            if (_dialogPage != null)
            {
                var result = await _dialogPage.DisplayAlert(
                     title,
                     message,
                     buttonConfirmText,
                     buttonCancelText);

                if (afterHideCallback != null)
                {
                    afterHideCallback(result);
                }

                return result;

            }
            return false;

        }


        public async Task ShowMessageBox(
            string message,
            string title)
        {
            if (_dialogPage != null)
                await _dialogPage.DisplayAlert(
                    title,
                    message,
                    "OK");
        }
        public DialogService()
        {

        }
        public DialogService(Page dialogPage)
        {
            _dialogPage = dialogPage;
        }

    }
}
