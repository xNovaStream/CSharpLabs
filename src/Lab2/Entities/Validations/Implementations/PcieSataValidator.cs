using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validations.Implementations;

public class PcieSataValidator : IValidator
{
    public ValidationReport Validate(Computer computer)
    {
        ArgumentNullException.ThrowIfNull(computer);

        uint usedPcieLines = computer.VideoCard.PcieLinesCount + computer.WifiAdapter.PcieLinesCount;
        uint usedSataPorts = 0;
        switch (computer.Drive.ConnectionOption)
        {
            case ConnectionOption.Pcie:
                usedPcieLines += 1;
                break;
            case ConnectionOption.Sata:
                usedSataPorts += 1;
                break;
            default:
                throw new NotImplementedException();
        }

        if (usedSataPorts > computer.Motherboard.SataPortsCount)
        {
            throw new PcieSataValidationException("Sata ports count not enough");
        }

        if (usedPcieLines > computer.Motherboard.PcieLinesCount)
        {
            throw new PcieSataValidationException("PCI-E lines count not enough");
        }

        return new ValidationReport();
    }
}