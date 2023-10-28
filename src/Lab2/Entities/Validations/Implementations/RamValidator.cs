using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validations.Implementations;

public class RamValidator : IValidator
{
    public ValidationReport Validate(Computer computer)
    {
        ArgumentNullException.ThrowIfNull(computer);

        if (computer.Rams.Count > computer.Motherboard.RamSlotsCount)
        {
            throw new RamValidationException("too many ram plates");
        }

        foreach (Ram ram in computer.Rams)
        {
            if (ram.DdrVersion != computer.Motherboard.SupportedDdrStandard)
            {
                throw new RamValidationException("ram's DDR not supported by motherboard");
            }

            if (ram.AvailableXmpProfiles.Count != 0 && !computer.Motherboard.Chipset.IsXmpSupported)
            {
                throw new RamValidationException("ram with XML Profile not supported by motherboard");
            }

            if (!computer.Motherboard.Chipset.AvailableMemoryFrequencies.Any(frequency =>
                    ram.JedecPairs.Any(jedecPair => jedecPair.Frequency == frequency)) &&
                !computer.Cpu.SupportedMemoryFrequencies.Any(frequency =>
                    ram.AvailableXmpProfiles.Any(xmpProfile => xmpProfile.Frequency == frequency)))
            {
                throw new RamValidationException("no available frequency");
            }
        }

        return new ValidationReport();
    }
}