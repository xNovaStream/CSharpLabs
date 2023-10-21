using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validations;

public class PowerUnitValidator : IValidator
{
    private const double OverestimationConsumedPower = 1.2;

    public ValidationReport Validate(Computer computer)
    {
        ArgumentNullException.ThrowIfNull(computer);

        uint sumConsumedPower = computer.Cpu.ConsumedPower + (uint)computer.Rams.Sum(ram => ram.ConsumedPower) +
                                computer.VideoCard.ConsumedPower + computer.Drive.ConsumedPower +
                                computer.WifiAdapter.ConsumedPower;
        if (computer.PowerUnit.PeakLoad < sumConsumedPower / OverestimationConsumedPower)
        {
            throw new PowerUnitValidationException("power unit is too weak");
        }

        if (computer.PowerUnit.PeakLoad < sumConsumedPower)
        {
            return new ValidationReport(warning: "peak load less, then required");
        }

        return new ValidationReport();
    }
}