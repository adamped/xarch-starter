using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Definition.Interfaces;
using GalaSoft.MvvmLight.Command;

namespace Mobile.ViewModel
{
    public class MainViewModel: BaseViewModel
    {
       
        private RelayCommand _aboutCommand;
        public RelayCommand AboutCommand
        {
            get
            {
                return _aboutCommand
                       ?? (_aboutCommand = new RelayCommand(
                           async () =>
                           {
                               using (var releaser = await _lock.LockAsync())
                               {
                                  
                               }

                           }));
            }
        }
    }
}
