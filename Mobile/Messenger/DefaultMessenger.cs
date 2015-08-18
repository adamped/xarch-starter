using Definition.Interfaces.Messenger;
using System;

namespace Mobile.Messenger
{
    public class DefaultMessenger : GalaSoft.MvvmLight.Messaging.Messenger, IDefaultMessenger
    {
        public void RegisterNotification(object recipient, Action<string> action)
        {
            Register<string>(recipient, action);            
        }

        public void SendNotification(string message)
        {
            Send<string>(message);
        }
    }
}
