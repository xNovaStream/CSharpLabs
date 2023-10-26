using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees.Implementations;

public class MessengerAddressee : IAddressee
{
    private readonly Messenger _messenger;

    public MessengerAddressee(Messenger messenger)
    {
        ArgumentNullException.ThrowIfNull(messenger);

        _messenger = messenger;
    }

    public void GetMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);

        _messenger.Send(message);
    }
}