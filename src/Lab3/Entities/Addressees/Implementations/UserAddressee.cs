using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees.Implementations;

public class UserAddressee : IAddressee
{
    private readonly User _user;

    public UserAddressee(User user)
    {
        ArgumentNullException.ThrowIfNull(user);

        _user = user;
    }

    public void GetMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);

        _user.GetMessage(message);
    }
}