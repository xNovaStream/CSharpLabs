using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees.Implementations;

public class CompositeAddressee : IAddressee
{
    private readonly List<IAddressee> _addressees;

    public CompositeAddressee(IEnumerable<IAddressee>? addressees = null)
    {
        _addressees = new List<IAddressee>(addressees ?? Array.Empty<IAddressee>());
    }

    public void SendMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);

        foreach (IAddressee addressee in _addressees)
        {
            addressee.SendMessage(message);
        }
    }

    public void AddAddressee(IAddressee addressee)
    {
        ArgumentNullException.ThrowIfNull(addressee);

        _addressees.Add(addressee);
    }

    public void RemoveAddressee(IAddressee addressee)
    {
        ArgumentNullException.ThrowIfNull(addressee);

        _addressees.Remove(addressee);
    }
}