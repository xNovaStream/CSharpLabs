using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities.Loggers;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities.Addressees.Implementations;

public class LoggingAddressee : IAddressee
{
    private readonly ILogger _logger;
    private IAddressee _addressee;

    public LoggingAddressee(IAddressee addressee, ILogger logger)
    {
        ArgumentNullException.ThrowIfNull(addressee);
        ArgumentNullException.ThrowIfNull(logger);

        _logger = logger;
        _addressee = addressee;
    }

    public void SetAddressee(IAddressee addressee)
    {
        ArgumentNullException.ThrowIfNull(addressee);

        _addressee = addressee;
    }

    public void GetMessage(Message message)
    {
        ArgumentNullException.ThrowIfNull(message);

        _addressee.GetMessage(message);
        _logger.Log("Log\n" +
                    "Addressee got message\n");
    }
}