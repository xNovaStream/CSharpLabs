using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validations;

public class WifiAdapterValidator : IValidator
{
    public ValidationReport Validate(Computer computer)
    {
        ArgumentNullException.ThrowIfNull(computer);

        if (computer.Motherboard.HaveWifiModule && computer.WifiAdapter is not NullWifiAdapter)
        {
            throw new WifiAdapterValidationException("network equipment conflict");
        }

        if (!computer.Motherboard.HaveWifiModule && computer.WifiAdapter is NullWifiAdapter)
        {
            return new ValidationReport(warning: "computer have no network equipment");
        }

        return new ValidationReport();
    }
}