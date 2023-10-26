using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Topic
{
    private IAddressee _addressee;

    public Topic(string name, IAddressee addressee)
    {
        ArgumentNullException.ThrowIfNull(addressee);
        ArgumentNullException.ThrowIfNull(name);

        Name = name;
        _addressee = addressee;
    }

    public string Name { get; }

    public void Send(Message message)
    {
        _addressee.GetMessage(message);
    }
}