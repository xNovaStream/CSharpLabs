using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees;

public interface IAddressee
{
    public void GetMessage(Message message);

    public void AddAddressee(IAddressee addressee) => throw new NotSupportedException();
    public void RemoveAddressee(IAddressee addressee) => throw new NotSupportedException();
}