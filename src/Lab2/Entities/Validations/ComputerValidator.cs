using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validations;

public class ComputerValidator : IValidator
{
    private readonly IReadOnlyList<IValidator> _validators;

    public ComputerValidator(params IValidator[] validators)
    {
        _validators = validators;
    }

    public ValidationReport Validate(Computer computer)
    {
        ArgumentNullException.ThrowIfNull(computer);

        var report = new ValidationReport();

        foreach (IValidator validator in _validators)
        {
            report.Add(validator.Validate(computer));
        }

        return report;
    }
}