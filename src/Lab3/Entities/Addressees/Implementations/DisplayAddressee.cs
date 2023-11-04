using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees.Implementations;

public class DisplayAddressee : IAddressee
{
    private readonly Display _display;

    public DisplayAddressee(Display display)
    {
        ArgumentNullException.ThrowIfNull(display);

        _display = display;
    }

    public void SendMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);

        _display.DisplayMessage(message);
    }
}