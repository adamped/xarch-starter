using Definition.Enums;
using GalaSoft.MvvmLight.Messaging;
using System;

namespace Definition.Interfaces.Messenger
{
    public interface IDefaultMessenger: IMessenger
    {

        void RegisterNotification(object recipient, Token token, Action<string> notify);

        void SendNotification(string message, Token token);

    }
}
