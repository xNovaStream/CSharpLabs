using System;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Components;
using Itmo.ObjectOrientedProgramming.Lab2.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validations;

public class VideoCardValidator : IValidator
{
    public ValidationReport Validate(Computer computer)
    {
        ArgumentNullException.ThrowIfNull(computer);

        if (computer is { VideoCard: NullVideoCard, Cpu.HaveIntegratedVideoCore: false })
        {
            throw new VideoCardValidationException("computer have no video card");
        }

        return new ValidationReport();
    }
}