using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Users;

public class User
{
    private readonly List<UserMessage> _messages = new();

    public User(string name, int age, string description = "")
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(description);

        Name = string.IsNullOrEmpty(name) ? throw new EmptyNameException() : name;
        Age = age >= 0 ? age : throw new InvalidAgeException();
        Description = description;
    }

    public string Name { get; }
    public int Age { get; }
    public string Description { get; }

    public IReadOnlyList<UserMessage> Messages => _messages;

    public void GetMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);

        _messages.Add(new UserMessage(message));
    }
}