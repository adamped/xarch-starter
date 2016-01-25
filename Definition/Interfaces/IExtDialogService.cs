using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Definition.Interfaces
{
    public interface IExtDialogService: IDialogService
    {
        void Init(Page dialogPage);
    }
}
