using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees.Implementations;

public class MessengerAddressee : IAddressee
{
    private readonly IMessenger _messenger;

    public MessengerAddressee(IMessenger messenger)
    {
        ArgumentNullException.ThrowIfNull(messenger);

        _messenger = messenger;
    }

    public void SendMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);

        _messenger.Send(message);
    }
}