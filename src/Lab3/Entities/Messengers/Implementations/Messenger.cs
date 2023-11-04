using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Messengers.Implementations;

public class Messenger : IMessenger
{
    private readonly ILogger _logger;

    public Messenger(string name, ILogger logger)
    {
        ArgumentNullException.ThrowIfNull(name);
        ArgumentNullException.ThrowIfNull(logger);

        Name = string.IsNullOrEmpty(name) ? throw new EmptyNameException() : name;
        _logger = logger;
    }

    public string Name { get; }

    public void Send(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);

        _logger.Log($"Messenger {Name}\n" +
                    $"{message.Header}\n" +
                    $"{message.Text}\n");
    }
}