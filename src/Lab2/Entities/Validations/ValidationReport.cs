using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities.Validations;

public class ValidationReport
{
    private readonly List<string> _descriptions;
    public ValidationReport(bool isValid = true, bool haveWarranty = true, string? description = null)
    {
        IsValid = isValid;
        HaveWarranty = isValid && haveWarranty;
        _descriptions = new List<string>();
        if (description != null)
        {
            _descriptions.Add(description);
        }
    }

    public bool IsValid { get; private set; }
    public bool HaveWarranty { get; private set; }
    public IReadOnlyList<string> Descriptions => _descriptions;

    public void Add(ValidationReport report)
    {
        ArgumentNullException.ThrowIfNull(report);

        if (IsValid) IsValid = report.IsValid;
        if (HaveWarranty) HaveWarranty = report.HaveWarranty;
        _descriptions.AddRange(report.Descriptions);
    }
}