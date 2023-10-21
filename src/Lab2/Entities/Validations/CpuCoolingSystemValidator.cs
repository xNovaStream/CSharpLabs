using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validations;

public class CpuCoolingSystemValidator : IValidator
{
    public ValidationReport Validate(Computer computer)
    {
        ArgumentNullException.ThrowIfNull(computer);

        if (!computer.CpuCoolingSystem.SupportedSockets.Contains(computer.Cpu.Socket))
        {
            throw new CpuCoolingSystemValidationException("cpu cooling system not supported cpu socket");
        }

        if (computer.CpuCoolingSystem.Tdp < computer.Cpu.Tdp)
        {
            return new ValidationReport(
                haveWarranty: false,
                warning: "cpu cooling system's TDP is too low");
        }

        return new ValidationReport();
    }
}