using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validations.Implementations;

public class ValidationReport
{
    private readonly List<string> _warnings;
    public ValidationReport(bool haveWarranty = true, string? warning = null)
    {
        HaveWarranty = haveWarranty;
        _warnings = new List<string>();
        if (warning != null)
        {
            _warnings.Add(warning);
        }
    }

    public bool HaveWarranty { get; private set; }
    public IReadOnlyList<string> Warnings => _warnings;

    public void Add(ValidationReport report)
    {
        ArgumentNullException.ThrowIfNull(report);

        if (HaveWarranty) HaveWarranty = report.HaveWarranty;
        _warnings.AddRange(report.Warnings);
    }
}