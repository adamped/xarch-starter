using Definition.Enums;
using Definition.Interfaces.Messenger;
using System;

namespace Mobile.Messenger
{
    public class DefaultMessenger : GalaSoft.MvvmLight.Messaging.Messenger, IDefaultMessenger
    {
        public void RegisterNotification(object recipient, Token token, Action<string> action)
        {
            Register<string>(recipient, token, action);            
        }

        public void SendNotification(string message, Token token)
        {
            Send<string>(message, token);
        }
    }
}
