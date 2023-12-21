using System;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees.Implementations;

public class ProtectedAddressee : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly int _minImportanceLevel;

    public ProtectedAddressee(IAddressee addressee, int minImportanceLevel = 0)
    {
        ArgumentNullException.ThrowIfNull(addressee);

        _addressee = addressee;
        _minImportanceLevel =
            minImportanceLevel >= 0 ? minImportanceLevel : throw new InvalidImportanceLevelException();
    }

    public void SendMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (message.ImportanceLevel < _minImportanceLevel) return;

        _addressee.SendMessage(message);
    }
}