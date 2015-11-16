using Definition.Enums;
using Definition.Interfaces.Messenger;
using System;

namespace Mobile.Messenger
{
    public class DefaultMessenger : GalaSoft.MvvmLight.Messaging.Messenger, IDefaultMessenger
    {
        public void RegisterNotification<T>(object recipient, Token token, Action<T> action)
        {
            Register<T>(recipient, token, action);            
        }

        public void SendNotification<T>(T message, Token token)
        {
            Send(message, token);
        }
    }
}
