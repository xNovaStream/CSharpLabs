using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validations.Implementations;

public class CpuValidator : IValidator
{
    public ValidationReport Validate(Computer computer)
    {
        ArgumentNullException.ThrowIfNull(computer);

        if (computer.Cpu.Socket != computer.Motherboard.CpuSocket)
        {
            throw new CpuValidationException("sockets on the motherboard and processor not compatible");
        }

        if (!computer.Motherboard.Bios.SupportedCpus.Contains(computer.Cpu))
        {
            throw new CpuValidationException("cpu not supported by BIOS");
        }

        return new ValidationReport();
    }
}