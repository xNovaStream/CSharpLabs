using System;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validations.Implementations;

public class CaseValidator : IValidator
{
    public ValidationReport Validate(Computer computer)
    {
        ArgumentNullException.ThrowIfNull(computer);

        if (!computer.Case.SupportedMotherboardFormFactors.Contains(computer.Motherboard.FormFactor))
        {
            throw new CaseValidationException("motherboard not fit into case");
        }

        if (computer.Case.MaxCpuCoolingSystemSize.X < computer.CpuCoolingSystem.Size.X ||
            computer.Case.MaxCpuCoolingSystemSize.Y < computer.CpuCoolingSystem.Size.Y ||
            computer.Case.MaxCpuCoolingSystemSize.Z < computer.CpuCoolingSystem.Size.Z)
        {
            throw new CaseValidationException("cpu cooling system not fit into case");
        }

        if (computer.Case.MaxVideoCardSize.X < computer.VideoCard.Size.X ||
            computer.Case.MaxVideoCardSize.Y < computer.VideoCard.Size.Y)
        {
            throw new CaseValidationException("video card not fit into case");
        }

        return new ValidationReport();
    }
}