using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees.Implementations;

public class ProtectedAddressee : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly uint _minImportanceLevel;

    public ProtectedAddressee(IAddressee addressee, uint minImportanceLevel = 0)
    {
        ArgumentNullException.ThrowIfNull(addressee);

        _addressee = addressee;
        _minImportanceLevel = minImportanceLevel;
    }

    public void GetMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);
        if (message.ImportanceLevel < _minImportanceLevel) return;

        _addressee.GetMessage(message);
    }
}