using Definition.Enums;
using GalaSoft.MvvmLight.Messaging;
using System;

namespace Definition.Interfaces.Messenger
{
    public interface IDefaultMessenger: IMessenger
    {

        void RegisterNotification<T>(object recipient, Token token, Action<T> notify);

        void SendNotification<T>(T message, Token token);

    }
}
