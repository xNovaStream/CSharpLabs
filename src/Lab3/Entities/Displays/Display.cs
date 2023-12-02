using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Displays;

public class Display
{
    private DisplayDriver _displayDriver;

    public Display(DisplayDriver displayDriver)
    {
        ArgumentNullException.ThrowIfNull(displayDriver);

        _displayDriver = displayDriver;
    }

    public void DisplayMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);

        _displayDriver.Clear();
        _displayDriver.WriteText($"{message.Header}\n" +
                                 $"{message.Text}\n");
    }
}